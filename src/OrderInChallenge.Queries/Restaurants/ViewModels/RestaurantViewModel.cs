using OrderInChallenge.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderInChallenge.Queries.Restaurants.ViewModels
{
    public class RestaurantViewModel
    {
        public RestaurantViewModel(Restaurant restaurant)
        {
            Id = restaurant.Id;
            Name = restaurant.Name;
            City = restaurant.City;
            Suburb = restaurant.Suburb;
            LogoPath = restaurant.LogoPath;
            Rank = restaurant.Rank;
            Categories = restaurant.Categories.Select(c => new CategoryViewModel(c)).ToList();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string LogoPath { get; set; }
        public int Rank { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }

    public class CategoryViewModel
    {
        public CategoryViewModel(Category category)
        {
            Name = category.Name;
            MenuItems = category.MenuItems.Select(mi => new MenuItemViewModel(mi)).ToList();
        }

        public string Name { get; set; }

        public List<MenuItemViewModel> MenuItems { get; set; }
    }

    public class MenuItemViewModel
    {
        public MenuItemViewModel(MenuItem menuItem)
        {
            Id = menuItem.Id;
            Name = menuItem.Name;
            Price = menuItem.Price;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
