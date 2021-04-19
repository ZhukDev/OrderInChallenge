using OrderInChallenge.DataAccess.Entities;
using System.Collections.Generic;

namespace OrderInChallenge.DataAccess.Abstractions
{
    public interface IRestaurantsService
    {
        IList<Restaurant> GetAllResturants();
        IList<Restaurant> GetResturantsByKey(string foodKey, string locationKey);
    }
}
