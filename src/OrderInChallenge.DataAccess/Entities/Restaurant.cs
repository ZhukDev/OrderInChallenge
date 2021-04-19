using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace OrderInChallenge.DataAccess.Entities
{
    public class Restaurant
    {
        [BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string LogoPath { get; set; }
        public int Rank { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
