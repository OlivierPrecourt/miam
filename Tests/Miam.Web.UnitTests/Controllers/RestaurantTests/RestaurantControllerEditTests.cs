using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Miam.Domain.Entities;
using Miam.Web.ViewModels.RestaurantViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;

namespace Miam.Web.UnitTests.Controllers.RestaurantTests
{
    [TestClass]
    public class RestaurantControllerEditTests : RestaurantControllerBaseTestsClass
    {
        [TestMethod]
        public void edit_should_return_view_with_restaurantViewModel_when_restaurantId_is_valid()
        {
            //Arrange 
            var restaurant = _fixture.Create<Restaurant>();
            _restaurantRepository.GetById(restaurant.Id).Returns(restaurant);
            var viewModelExpected = Mapper.Map<RestaurantEditViewModel>(restaurant);

            //Action
            var viewResult = _restaurantController.EditRestaurant(restaurant.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as RestaurantEditViewModel;

            //Assert 
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected); 
        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_restaurantID_is_not_valid()
        {
            //Arrange 

            //Act
            var result = _restaurantController.EditRestaurant(999999999);
            
            //Assert
            result.Should().BeOfType<HttpNotFoundResult>();
            
            // M�me assertion, mais sans fluent assertion
            // Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult)); 
            
        }


        [TestMethod]
        public void edit_post_should_update_restaurant_when_restaurantId_is_valid()
        {
            //Arrange
            var restaurant = _fixture.Create<Restaurant>();
            _restaurantRepository.GetById(restaurant.Id).Returns(restaurant);
            var restaurantViewModel = Mapper.Map<RestaurantEditViewModel>(restaurant);

            //Action
            var actionResult = _restaurantController.EditRestaurant(restaurantViewModel);

            // Assert
            _restaurantRepository.Received().Update(Arg.Is<Restaurant>(x => x.Id == restaurant.Id));

        }

        [TestMethod]
        public void edit_post_should_redirect_to_index_on_success()
        {
            //Arrange
            var restaurant = _fixture.Create<Restaurant>();
            _restaurantRepository.GetById(restaurant.Id).Returns(restaurant);
            var restaurantEditPageViewModel = Mapper.Map<Restaurant, RestaurantEditViewModel>(restaurant);

            //Act
            var routeResult = _restaurantController.EditRestaurant(restaurantEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);

        }

        [TestMethod]
        public void edit_post_should_return_view_with_errors_when_modelState_is_not_valid()
        {
            //Arrange
            var restaurant = _fixture.Create<Restaurant>();
            var restaurantEditPageViewModel = _fixture.Build<RestaurantEditViewModel>()
                                                      .With(x=>x.Id, restaurant.Id)
                                                      .Create();
            _restaurantRepository.GetById(restaurant.Id).Returns(restaurant);
            _restaurantController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = _restaurantController.EditRestaurant(restaurantEditPageViewModel) as ViewResult;
            var viewName = result.ViewName;

            //Assert
            
            viewName.Should().Be("");
            
        }
    }
}