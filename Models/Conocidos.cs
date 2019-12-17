using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Backend.Models
{
  [BsonIgnoreExtraElements]
  public class Conocidos
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; }

    public string id_usuario { get; set; }

    public string nombre { get; set; }

    public string parentesco { get; set; }

    public string correo { get; set; }

  }
}
