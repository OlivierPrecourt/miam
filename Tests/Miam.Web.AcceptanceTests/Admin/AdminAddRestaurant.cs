﻿using FluentAssertions;
using Miam.Domain.Entities;
using Miam.TestUtility.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.Admin
{
    [TestClass]
    [Story(
        Title = "Un administrateur peut ajouter un restaurantExpected",
        AsA = "En tant qu'administrateur",
        IWant = "Je veux pouvoir ajouter un restaurantExpected",
        SoThat = "Afin d'avoir un nouveau restaurantExpected dans le système")]
    public class AdminAddRestaurant : AdminBaseClass
    {
        [TestMethod]
        public void ajouter_un_restaurant()
        {
            this.Given(x => un_administrateur_authentifé())
                .When(x => l_administrateur_ajoute_un_restaurant())
                .Then(x => le_restaurant_est_ajouté())
                .BDDfy();
        }

        private void l_administrateur_ajoute_un_restaurant()
        {
            var createRestaurantPage = _homePage.GoToCreateRestaurantPage();
            createRestaurantPage.AddRestaurant(TestData.Restaurant2);
        }

        private void le_restaurant_est_ajouté()
        {
            var restaurant = _restaurantAcceptanceTestApi.GetFirstRestaurant();
            AssertRestaurantsShouldBeEquivalent(TestData.Restaurant2, restaurant);
        }
    }
}
