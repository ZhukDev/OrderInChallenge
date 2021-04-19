using MediatR;
using OrderInChallenge.DataAccess.Abstractions;
using OrderInChallenge.Queries.Restaurants.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderInChallenge.Queries.Restaurants.Search
{
    public class SearchRestaurantsQueryHandler : IRequestHandler<SearchRestaurantsQuery, IEnumerable<RestaurantViewModel>>
    {
        private readonly IRestaurantsService _restaurantsService;

        public SearchRestaurantsQueryHandler(IRestaurantsService restaurantsService)
        {
            _restaurantsService = restaurantsService;
        }

        public Task<IEnumerable<RestaurantViewModel>> Handle(SearchRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var lowerSearchKeysList = request.Keyword.ToLower().Split("in").Select(p => p.Trim()).ToList();
            string food = lowerSearchKeysList.FirstOrDefault();
            string location = lowerSearchKeysList.LastOrDefault();
            //filter menuItems results and ordered by menuItems count and then by rank(desc)
            var restaurants = _restaurantsService
                                .GetResturantsByKey(food, location)
                                    .Select(r => new RestaurantViewModel(r) { 
                                        Categories = r.Categories.Select(c => new CategoryViewModel(c)
                                            {
                                                MenuItems =  c.MenuItems
                                                                    .Where(mi => (food.Equals(location) 
                                                                                    && (r.City.ToLower().Contains(location)
                                                                                        || r.Suburb.ToLower().Contains(location)
                                                                                        )
                                                                                    ) || mi.Name.ToLower().Contains(food))
                                                                    .Select(mi => new MenuItemViewModel(mi)).ToList()
                                            }).Where(c => c.MenuItems.Any()).ToList()
                                    }).OrderByDescending(r => r.Categories.SelectMany(c => c.MenuItems).Count()).ThenByDescending(r => r.Rank);

            return Task.FromResult<IEnumerable<RestaurantViewModel>>(restaurants);
        }
    }
}
