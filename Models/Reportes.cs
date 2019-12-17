using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
  [BsonIgnoreExtraElements]
  public class Reportes
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string id_usuario { get; set; }

    public DateTime fecha { get; set; }

    public string descripcion { get; set; }

    public string ubicacion { get; set; }

    public double postivos { get; set; }

    public double negativos { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string tipo_reporte { get; set; }

    public double latitud { get; set; }

    public double longitud { get; set; }

    public double denuncias { get; set; }

    public bool emergencia { get; set; }

    public List<String> imagenes { get; set; }

  }
}