using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerceDDD.Infra.Data.Mongo.Models
{
    public class ClienteReadModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
