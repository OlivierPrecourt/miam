﻿using System;
using Miam.Domain.Entities;
using Miam.Web.Automation.PageObjects.RestaurantPages;
using Miam.Web.Automation.Selenium;
using Miam.Web.Automation.Seleno;
using Miam.Web.Controllers;
using OpenQA.Selenium;
using TestStack.Seleno.PageObjects;

namespace Miam.Web.Automation.PageObjects
{
    public class HomePage : Page
    {
        // Seleno
        public LoginPage GoToLoginPage()
        {
            return Navigate.To<LoginPage>(By.Id("login-link"));
;       }

        public EditRestaurantPage GoToEditRestaurantPage()
        {
            Find.Element(By.Id("admin-menu"))
                .Click();
            return Navigate.To<EditRestaurantPage>(By.Id("manage-restaurant-menu-item"));
        }

        public CreateRestaurantPage GoToCreateRestaurantPage()
        {
            Find.Element(By.Id("admin-menu"))
                .Click();
            return Navigate.To<CreateRestaurantPage>(By.Id("add-restaurant-menu-item"));
        }

        public bool SelenoIsLogged(string email)
        {

            var navigationMenu = Find.Element(By.ClassName("navbar"));
            return navigationMenu.Text.Contains(email);
        }

        public int RestaurantCount()
        {
            var countText = Find.Element(By.Id("restaurants-count"))
                                .Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public void LogOut()
        {
            Host.Instance.NavigateToInitialPage<AccountController, LoginPage>(x => x.Logout());
        }
        
       
        // Avant 
        private static int _lastCount;
        public static bool IsAdminLogged
        {
            get
            {
                var body = Driver.Instance.FindElement(By.ClassName("navbar"));
                return body.Text.Contains("Admin");
            } 
        }
        public static bool IsWriterLogged
        {
            get
            {
                try
                {
                    Driver.Instance.FindElement(By.Id("writer-menu"));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        
        public static bool HasRestaurant
        {
            get
            {
                return GetRestaurantCount() > 0; 
            }
        }

        public static int PreviousRestaurantCount
        {
            get { return _lastCount; }
        }
        public static void StoreRestaurtantCount()
        {
            _lastCount = GetRestaurantCount();
        }
        public static int CurrentRestaurantCount
        {
            get { return GetRestaurantCount(); }
        }
        private static int GetRestaurantCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("restaurants-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static bool DoesRestaurantNameExist(string textToFind)
        {
            var body = Driver.Instance.FindElement(By.ClassName("list-group"));
            return body.Text.Contains(textToFind);
        }

        public static void GoTo()
        {
            Navigation.AllUsers.Home.Select();
        }


        
    }
}
