﻿using FluentAssertions;
using Miam.Domain.Entities;
using Miam.TestUtility.Database;

namespace Miam.Web.AcceptanceTests.AdminAcceptanceTests
{
    public class AdminBaseClass : AcceptanceTestsBaseClass
    {
        protected ApplicationUser _userAdmin;
        protected Restaurant _restaurant1;

        protected void un_administrateur_authentifé()
        {
            _userAdmin = TestData.ApplicationUserAdmin;
            _userAcceptanceTestApi.createUser(_userAdmin);

            var loginPage = _homePage.GoToLoginPage();
            loginPage.LoginAs(_userAdmin.Email, _userAdmin.Password);
        }
        protected void un_restaurant_existe_dans_le_système()
        {
            _restaurant1 = TestData.Restaurant1;
            _restaurantAcceptanceTestApi.CreateRestaurant(_restaurant1);
        }

        protected void AssertRestaurantsShouldBeEquivalent(Restaurant expectedRestaurant, Restaurant obtainedRestaurant)
        {
            expectedRestaurant.Name.ShouldBeEquivalentTo(obtainedRestaurant.Name);
            expectedRestaurant.City.ShouldBeEquivalentTo(obtainedRestaurant.City);
            expectedRestaurant.Country.ShouldBeEquivalentTo(obtainedRestaurant.Country);
        }

        protected void AssertContactDetailsShouldBeEquivalent(RestaurantContactDetail contactDetailsExpected, RestaurantContactDetail contactDetailsObtained)
        {
            contactDetailsExpected.FaxPhone.ShouldBeEquivalentTo(contactDetailsObtained.FaxPhone);
            contactDetailsExpected.OfficePhone.ShouldBeEquivalentTo(contactDetailsObtained.OfficePhone);
            contactDetailsExpected.TwitterAlias.ShouldBeEquivalentTo(contactDetailsObtained.TwitterAlias);
            contactDetailsExpected.Facebook.ShouldBeEquivalentTo(contactDetailsObtained.Facebook);
            contactDetailsExpected.WebPage.ShouldBeEquivalentTo(contactDetailsObtained.WebPage);
        }
    }
}
