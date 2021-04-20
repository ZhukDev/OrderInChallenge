using MongoDB.Bson.Serialization.Attributes;

namespace OrderInChallenge.DataAccess.Entities
{
    public class MenuItem
    {
        public MenuItem(string id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
