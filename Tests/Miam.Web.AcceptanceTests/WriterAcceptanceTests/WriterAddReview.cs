﻿using Miam.Domain.Entities;
using Miam.TestUtility.Database;
using Miam.Web.AcceptanceTests.AdminAcceptanceTests;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.WriterAcceptanceTests
{
    [TestClass]
    [Story(
        Title = "Un chroniqueur peut ajouter une appréciation sur restaurant",
        AsA = "En tant que chroniqueur",
        IWant = "Je veux  pouvoir écrire une chronique",
        SoThat = "Afin de donner mon appréciation sur un restaurant")]
    public class WriterAddReview : AcceptanceTestsBaseClass
    {
        private Writer _writer;

        [TestMethod]
        public void s_authentifier_avec_courriel_et_mot_de_passe_valide()
        {
            this.Given(x => un_chroniqueur_authentifé())
                .Given(x => un_restaurant())
                .When(x => le_chroniqueur_ajoute_une_appréciation_sur_un_restaurant())
                .Then(x => l_appréciation_devrait_être_ajouté())
                .BDDfy();
        }

        private void un_chroniqueur_authentifé()
        {
            _writer = TestData.Writer1;
            _userAcceptanceTestApi.createUser(_writer);

            _homePage
                .Menu
                .GotoLoginPage()
                .LoginAs(_writer.Email, _writer.Password);
        }

        private void un_restaurant()
        {
            throw new System.NotImplementedException();
        }

        private void le_chroniqueur_ajoute_une_appréciation_sur_un_restaurant()
        {
            throw new System.NotImplementedException();
        }

        private void l_appréciation_devrait_être_ajouté()
        {
            throw new System.NotImplementedException();
        }
        
    }
}
 
