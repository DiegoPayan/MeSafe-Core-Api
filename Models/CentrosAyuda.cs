using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
  [BsonIgnoreExtraElements]
  public class CentrosAyuda
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; }

    public string nombre { get; set; }

    public string numero { get; set; }

    public string direccion { get; set; }

    public string tipo { get; set; }
  }
}