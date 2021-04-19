using System.Collections.Generic;

namespace OrderInChallenge.DataAccess.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
