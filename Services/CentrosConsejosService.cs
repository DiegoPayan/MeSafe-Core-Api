using System.Collections.Generic;
using Backend.Models;
using MongoDB.Driver;

namespace Backend.Services
{
  public class CentrosConsejosService
  {
    private readonly IMongoCollection<CentrosAyuda> _centrosAyuda;
    private readonly IMongoCollection<Consejos> _consejos;

    public CentrosConsejosService(IMeSafeDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _centrosAyuda = database.GetCollection<CentrosAyuda>(settings.CentrosAyudaCollectionName);
      _consejos = database.GetCollection<Consejos>(settings.ConsejosCollectionName);
    }

    public List<CentrosAyuda> GetCentros() =>
      _centrosAyuda.Find(rol => true).ToList();

    public List<Consejos> GetConsejos() =>
      _consejos.Find(rol => true).ToList();
  }
}