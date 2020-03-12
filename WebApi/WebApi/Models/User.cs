using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace WebApi.Models
{
    public class User
    {
        //Not using mongodb
        //public int Id { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        //public string Role { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        [JsonProperty("Name")]
        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
