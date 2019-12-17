using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Backend.Models
{
  [BsonIgnoreExtraElements]
  public class Consejos
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; }

    public string consejo { get; set; }

  }
}
