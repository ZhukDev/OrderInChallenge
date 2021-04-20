using FluentAssertions;
using OrderInChallenge.Api.Integration.Tests.Fixtures;
using OrderInChallenge.Api.Integration.Tests.Fixtures.Collections;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OrderInChallenge.Api.Integration.Tests.Controllers
{
    [Collection(nameof(OrderInChallengeServerCollection))]
    public class RestaurantsControllerTests
    {
        private readonly OrderInChallengeServerFixture fixture;

        public RestaurantsControllerTests(OrderInChallengeServerFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task GetAllResturants_ValidRequest_HttpStatusCodeOK()
        {
            // Arrange
            var uriBuilder = new UriBuilder(this.fixture.HttpClient.BaseAddress)
            {
                Path = "api/restaurants"
            };

            // Act
            var response = await this.fixture.HttpClient.GetAsync(uriBuilder.Uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetResturantsByKey_ValidRequest_HttpStatusCodeOK()
        {
            // Arrange
            var uriBuilder = new UriBuilder(this.fixture.HttpClient.BaseAddress)
            {
                Path = "api/restaurants/taco"
            };

            // Act
            var response = await this.fixture.HttpClient.GetAsync(uriBuilder.Uri);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
