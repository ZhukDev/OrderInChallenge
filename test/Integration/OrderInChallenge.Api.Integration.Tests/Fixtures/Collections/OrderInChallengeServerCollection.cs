using Xunit;

namespace OrderInChallenge.Api.Integration.Tests.Fixtures.Collections
{
    [CollectionDefinition(nameof(OrderInChallengeServerCollection))]
    public class OrderInChallengeServerCollection : ICollectionFixture<OrderInChallengeServerFixture>
    {
    }
}
