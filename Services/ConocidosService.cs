using System.Collections.Generic;
using Backend.DTO;
using Backend.Models;
using MongoDB.Driver;

namespace Backend.Services
{
  public class ConocidosService
  {
    private readonly IMongoCollection<Conocidos> _conocidos;

    public ConocidosService(IMeSafeDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _conocidos = database.GetCollection<Conocidos>(settings.ConocidosCollectionName);
    }

    public List<Conocidos> getSolicitudes(string id) =>
      _conocidos.Find(conocidos => conocidos.id_usuario == id).ToList();

    public Conocidos Create(Conocidos conocidos)
    {
      _conocidos.InsertOne(conocidos);
      return conocidos;
    }


  }
}