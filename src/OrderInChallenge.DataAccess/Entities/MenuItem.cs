using MongoDB.Bson.Serialization.Attributes;

namespace OrderInChallenge.DataAccess.Entities
{
    public class MenuItem
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
