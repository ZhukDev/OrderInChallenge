using MediatR;
using OrderInChallenge.Queries.Restaurants.ViewModels;
using System.Collections.Generic;

namespace OrderInChallenge.Queries.Restaurants.Search
{
    public class SearchRestaurantsQuery : IRequest<IEnumerable<RestaurantViewModel>>
    {
        public string Keyword { get; set; }
    }
}
