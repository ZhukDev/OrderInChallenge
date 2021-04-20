using System.Collections.Generic;

namespace OrderInChallenge.DataAccess.Entities
{
    public class OrderItem
    {
        public OrderItem(string restaurantId, ICollection<MenuItem> menuItems)
        {
            RestaurantId = restaurantId;
            MenuItems = menuItems;
        }

        public string RestaurantId { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
