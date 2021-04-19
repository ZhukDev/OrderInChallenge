using MongoDB.Driver;
using OrderInChallenge.DataAccess.Entities;

namespace OrderInChallenge.DataAccess
{
    public class AppDbContext
    {
        private readonly IMongoDatabase _db;

        public AppDbContext(IMongoClient client, string dbName)
        {
            _db = client.GetDatabase(dbName);
        }

        public IMongoCollection<Restaurant> Restaurants => _db.GetCollection<Restaurant>(nameof(Restaurants));
        public IMongoCollection<Category> Categories => _db.GetCollection<Category>(nameof(Categories));
        public IMongoCollection<MenuItem> MenuItems => _db.GetCollection<MenuItem>(nameof(MenuItems));
    }
}
