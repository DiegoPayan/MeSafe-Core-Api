using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Backend.Models
{
  [BsonIgnoreExtraElements]
  public class Usuarios
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; }

    public string nombres { get; set; }

    public string apellidos { get; set; }

    public string email { get; set; }

    public string password { get; set; }

    public string estado { get; set; }

    public string municipio { get; set; }

    public string colonia { get; set; }

    public string genero { get; set; }

    public string edad { get; set; }

    public string ocupacion { get; set; }

    public string celular { get; set; }

    public string id_rol { get; set; }

    public string imagen { get; set; }

    public string registro_completo { get; set; }

    public string censura_imagenes { get; set; }

    public string estatus { get; set; }

    public string toString()
    {
      return nombres + " " + apellidos + " " + email + " " + password + " " + estado + " " + municipio + " " + colonia + " " + genero + " " + edad + " " + ocupacion + " " + celular + " " + id_rol + " " + imagen + " " + registro_completo + " " + censura_imagenes + " " + estatus;
    }
  }
}