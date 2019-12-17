using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Backend.Models
{
  [BsonIgnoreExtraElements]
  public class Roles
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; }

    public string nombre { get; set; }
  }
}