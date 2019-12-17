using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
  [BsonIgnoreExtraElements]
  public class ReportesImagenes
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string id_reporte { get; set; }

    public string imagen { get; set; }

    public int reportes_censura { get; set; }

    public string estatus { get; set; }
  }
}