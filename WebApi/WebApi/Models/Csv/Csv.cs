using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace WebApi.Models
{
    [BsonIgnoreExtraElements]
    public class Csv
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement()]
        [JsonProperty()]
        public string Nome { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }
    }
}
