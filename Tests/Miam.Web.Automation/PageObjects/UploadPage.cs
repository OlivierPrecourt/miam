﻿using System;
using System.IO;
using System.Linq;
using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Miam.Web.Automation.PageObjects
{
    public class UploadPage
    {
        public static void Goto()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "/File/Upload");
        }

        public static void UploadTestFile(String filename)
        {
            // Les fichiers pour les tests se trouvent dans le dossier /TestFiles du projet des tests d'acceptation.
            
            //SUR JENKINS
            //  - Le dossier TestFiles se trouve à l'emplacement suivant:
            //    ..\workspace\Tests\Miam.Web.AcceptanceTests\TestFiles
            //  - Le projet compilé se trouve dans un autre dossier (qui est unique pour chacune des compilations). 
            //    ..\workspace\Système_JENKINS 2014-11-11 15_48_09\Out
            
            //EN LOCAL 
            //  - Le projet compilé se trouve à l'emplacement suivant:
            //    ..\Tests\Miam.Web.AcceptanceTests\bin\Debug
            //  - Le dossier TestFiles se trouve à l'emplacement suivant:
            //    ..\Tests\Miam.Web.AcceptanceTests\TestFiles
            
            //PROBLÈME: 
            //  - Le chemin relatif "." est le dossier où se trouve les fichiers compilés des tests d'acceptation
            //  - Les chemins relatifs pour accéder au dossier TestFiles diffèrent entre Jenkins et en local.
            //  - Pour Jenkins, il faut remonter de deux dossiers ("../..") et ensuite aller dans Tests\Miam.Web.AcceptanceTests\TestFiles
            //  - En local, il faut remonter de deux dossiers ("../..") et ensuite aller dans TestFiles.

            //SOLUTION: 
            //  - Rechercher le dossier TestFiles dans l'arborescence.
            //  - Un seul dossier TestFile doit exister dans la solution.
 
            var folderTestFilesPath = Directory.GetDirectories(Path.GetFullPath("../../"), "TestFiles", SearchOption.AllDirectories)
                                               .FirstOrDefault();
            var fullPath = Path.Combine(folderTestFilesPath, filename);


            Driver.Instance.FindElement(By.Id("filename")).SendKeys(fullPath);
            Driver.Instance.FindElement(By.Id("submit_button")).Click();
        }
    }
}