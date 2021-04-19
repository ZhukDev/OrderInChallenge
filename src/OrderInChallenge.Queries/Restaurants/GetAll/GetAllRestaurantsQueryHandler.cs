﻿using MediatR;
using OrderInChallenge.DataAccess.Abstractions;
using OrderInChallenge.Queries.Restaurants.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderInChallenge.Queries.Restaurants.GetAll
{
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantViewModel>>
    {
        private readonly IRestaurantsService restaurantsService;

        public GetAllRestaurantsQueryHandler(IRestaurantsService restaurantsService)
        {
            this.restaurantsService = restaurantsService;
        }

        public Task<IEnumerable<RestaurantViewModel>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var restaurants = restaurantsService.GetAllResturants().Select(r => new RestaurantViewModel(r));

            return Task.FromResult(restaurants);
        }
    }
}
