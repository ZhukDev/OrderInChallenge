using System.Threading;
using System.Threading.Tasks;

namespace OrderInChallenge.DataAccess.Seeder.Abstractions
{
    public interface IDbInitializer
    {
        Task InitializeAsync(CancellationToken cancellationToken = default);
    }
}
