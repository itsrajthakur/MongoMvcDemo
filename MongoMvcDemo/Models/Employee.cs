using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoMvcDemo.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = "";
        public string Position { get; set; } = "";
        public decimal Salary { get; set; }
    }
}