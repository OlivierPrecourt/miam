﻿using System;
using Miam.Domain.Entities;
using Miam.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Miam.Web.Automation.PageObjects
{
    public class LoginPage
    {
        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("login-page"));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static void GoTo()
        {
            Navigation.AllUsers.Login.Select();
        }

        public static void LoginAs(ApplicationUser user)
        {
            var loginInput = Driver.Instance.FindElement(By.Id("Email"));
            loginInput.SendKeys(user.Email);

            var passwordInput = Driver.Instance.FindElement(By.Id("Password"));
            passwordInput.SendKeys(user.Password);

            var loginButton = Driver.Instance.FindElement(By.Id("login-submit"));
            loginButton.Click();
        }

    }
}
