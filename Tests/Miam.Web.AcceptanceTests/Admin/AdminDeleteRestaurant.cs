﻿using FluentAssertions;
using Miam.TestUtility.Database;
using Miam.Web.Automation.AcceptanceTestApi;
using Miam.Web.Automation.PageObjects;
using Miam.Web.Automation.PageObjects.RestaurantPages;
using Miam.Web.Automation.Seleno;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.Web.AcceptanceTests.Admin
{
    [TestClass]
    [Story(
        Title = "Un administrateur peut supprimer un restaurant",
        AsA = "En tant qu'administrateur",
        IWant = "Je veux pouvoir supprimer un restaurant",
        SoThat = "Afin qu'il ne soit plus dans le système")]
    public class AdminDeleteRestaurant : AdminBaseClass
    {
        [TestMethod]
        public void supprimer_un_restaurant()
        {
            this.Given(x => un_administrateur_authentifé())
                .Given(x => un_restaurant_existe_dans_le_système())
                .When(x => l_administrateur_supprime_un_restaurant())
                .Then(x => le_restaurant_est_supprimé())
                .BDDfy();
        }

        private void l_administrateur_supprime_un_restaurant()
        {
            var editRestaurantPage = _homePage.GoToEditRestaurantPage();
            editRestaurantPage.DeleteFisrtRestaurant();

        }
        private void le_restaurant_est_supprimé()
        {
            var countRestaurant = _homePage.RestaurantCount();
            countRestaurant.ShouldBeEquivalentTo(0);
        }




    }

}
