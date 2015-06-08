﻿using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.Seleno;
using Miam.Web.Controllers;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.Web.Automation.UiComponents
{
    public class LoginPanel : UiComponent
    {
        public string LoggedInUserName
        {
            get { return Find.Element(By.Id("login-username")).Text; }
        }

        public void ForceLogout()
        {
            Host.Instance.NavigateToInitialPage<AccountController, LoginPage>(x => x.Logout());
        }

        public void Logout()
        {
            Find.Element(By.Id("logout-link"))
                .Click();
        }


        public bool IsLoggedIn(string email)
        {
            var navigationMenu = Find.Element(By.ClassName("navbar"));
            return navigationMenu.Text.Contains(email);
        }

    }
}
