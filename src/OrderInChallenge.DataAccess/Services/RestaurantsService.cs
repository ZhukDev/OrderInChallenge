using MongoDB.Driver;
using OrderInChallenge.DataAccess.Abstractions;
using OrderInChallenge.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderInChallenge.DataAccess.Services
{
    public class RestaurantsService : IRestaurantsService
    {
        private readonly AppDbContext _db;

        public RestaurantsService(AppDbContext db)
        {
            _db = db;
        }

        public IList<Restaurant> GetAllResturants()
        {
            return _db.Restaurants.AsQueryable().ToList();
        }

        public IList<Restaurant> GetResturantsByKey(string foodKey, string locationKey)
        {
            IList<Restaurant> result = null;
            if (foodKey.Equals(locationKey))
            {
                result = _db.Restaurants.AsQueryable().Where(r => r.City.ToLower().Contains(locationKey)
                                                                    || r.Suburb.ToLower().Contains(locationKey)
                                                                    || r.Categories.Any(c => c.Name.ToLower().Contains(foodKey))
                                                                    || r.Categories.Any(c => c.MenuItems.Any(mi => mi.Name.ToLower().Contains(foodKey)))
                                                            ).ToList();
            }
            else
            {
                result = _db.Restaurants.AsQueryable().Where(r => (r.City.ToLower().Contains(locationKey)
                                                                    || r.Suburb.ToLower().Contains(locationKey))
                                                                    && (r.Categories.Any(c => c.Name.ToLower().Contains(foodKey))
                                                                    || r.Categories.Any(c => c.MenuItems.Any(mi => mi.Name.ToLower().Contains(foodKey))))
                                                            ).ToList();
            }

            return result;
        }
    }
}
