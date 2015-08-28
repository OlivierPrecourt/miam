using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.Restaurant;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers.RestaurantTests
{
    [TestClass]
    public class RestaurantControllerCreateTests : BaseRestaurantControllerTests
    {
        [TestMethod]
        public void create_action_should_render_default_view()
        {
            var result = RestaurantController.Create() as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void create_post_should_add_restaurant_to_repository()
        {
            // Arrange   
            var restaurant = _fixture.Create<Restaurant>();

            var restaurantViewModel = Mapper.Map<RestaurantCreateViewModel>(restaurant); 

            // Action
            RestaurantController.Create(restaurantViewModel);

            // Assert
            RestaurantRepositoryAddMethodShouldHaveReceived(restaurant);
            
        }

        [TestMethod]
        public void create_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            var restaurantViewModel = _fixture.Create<RestaurantCreateViewModel>();
            RestaurantController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = RestaurantController.Create(restaurantViewModel) as ViewResult;

            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void create_post_should_redirect_to_home_index_on_success()
        {
            //Arrange
            var restaurantViewModel = _fixture.Create<RestaurantCreateViewModel>();

            //Act
            var result = RestaurantController.Create(restaurantViewModel) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];


            //Assert
            action.ShouldBeEquivalentTo(MVC.Home.Views.ViewNames.Index);

        }
        private void RestaurantRepositoryAddMethodShouldHaveReceived(Restaurant restaurant)
        {
            RestaurantRepository.Received().Add(Arg.Is<Restaurant>(x => x.Id == restaurant.Id));
            RestaurantRepository.Received().Add(Arg.Is<Restaurant>(x => x.City == restaurant.City));
            RestaurantRepository.Received().Add(Arg.Is<Restaurant>(x => x.Country == restaurant.Country));
            RestaurantRepository.Received().Add(Arg.Is<Restaurant>(x => x.Name == restaurant.Name));
        }


    }
}

