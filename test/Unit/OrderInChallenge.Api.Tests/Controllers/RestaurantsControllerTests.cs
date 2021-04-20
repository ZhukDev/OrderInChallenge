using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OrderInChallenge.Api.Controllers;
using OrderInChallenge.Queries.Restaurants.GetAll;
using OrderInChallenge.Queries.Restaurants.Search;
using OrderInChallenge.Queries.Restaurants.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OrderInChallenge.Api.Tests.Controllers
{
    public class RestaurantsControllerTests
    {
        private readonly Mock<ISender> senderMock;
        private readonly RestaurantsController sut;

        public RestaurantsControllerTests()
        {
            this.senderMock = new Mock<ISender>();
            this.sut = new RestaurantsController(this.senderMock.Object);
        }

        [Fact]
        public async Task GetAllRestaurants_WhenCalled_ShouldSendQuery()
        {
            // Arrange

            this.senderMock
                .Setup(m => m.Send(It.IsAny<GetAllRestaurantsQuery>(), default))
                .ReturnsAsync(It.IsAny<IEnumerable<RestaurantViewModel>>());

            // Act
            await this.sut.GetAllResturants();

            // Assert
            this.senderMock.Verify(x => x.Send(It.IsAny<GetAllRestaurantsQuery>(), default), Times.Once);
        }

        [Theory, AutoMoqData]
        public async Task GetResturantsByKey_WhenCalled_ShouldSendQuery(string keyword)
        {
            // Arrange
            this.senderMock
                .Setup(m => m.Send(It.IsAny<SearchRestaurantsQuery>(), default))
                .ReturnsAsync(It.IsAny<IEnumerable<RestaurantViewModel>>());

            // Act
            await this.sut.GetResturantsByKey(keyword);

            // Assert
            this.senderMock.Verify(x => x.Send(It.IsAny<SearchRestaurantsQuery>(), default), Times.Once);
        }

        [Fact]
        public async Task GetAllRestaurants_WhenExistsRestaurants_ShouldBeOkObjectResult()
        {
            // Arrange
            this.senderMock
                .Setup(m => m.Send(It.IsAny<GetAllRestaurantsQuery>(), default))
                .ReturnsAsync(Array.Empty<RestaurantViewModel>());

            // Act
            var actual = await this.sut.GetAllResturants();

            // Assert
            actual.Should().BeOfType<OkObjectResult>();
        }
    }
}
