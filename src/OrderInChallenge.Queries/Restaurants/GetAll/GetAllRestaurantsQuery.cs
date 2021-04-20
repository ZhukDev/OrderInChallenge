using MediatR;
using OrderInChallenge.Queries.Restaurants.ViewModels;
using System.Collections.Generic;

namespace OrderInChallenge.Queries.Restaurants.GetAll
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantViewModel>>
    {
    }
}
