using DotNet.Testcontainers.Containers;
using DotNet.Testcontainers.Containers.Builders;
using DotNet.Testcontainers.Containers.Modules;
using DotNet.Testcontainers.Containers.WaitStrategies;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using OrderInChallenge.DataAccess.Seeder.Abstractions;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace OrderInChallenge.Api.Integration.Tests.Fixtures
{
    public class OrderInChallengeServerFixture : IAsyncLifetime
    {
        private readonly IDockerContainer mongoDbContainer;
        private readonly WebApplicationFactory<Startup> webApplicationFactory;

        public OrderInChallengeServerFixture()
        {
            this.webApplicationFactory = new WebApplicationFactory<Startup>();
            this.mongoDbContainer = new TestcontainersBuilder<TestcontainersContainer>()
                .WithImage("mongo")
                .WithName("orderInTest")
                .WithPortBinding(27017)
                .WithWaitStrategy(Wait.ForUnixContainer().UntilPortIsAvailable(27017))
                .Build();
        }

        public HttpClient HttpClient { get; private set; }

        public async Task InitializeAsync()
        {
            await this.mongoDbContainer.StartAsync();
            await this.webApplicationFactory.Services
                .GetService<IDbInitializer>()
                .InitializeAsync();

            this.HttpClient = this.webApplicationFactory.CreateClient();
        }

        public Task DisposeAsync() => this.mongoDbContainer.DisposeAsync().AsTask();
    }
}
