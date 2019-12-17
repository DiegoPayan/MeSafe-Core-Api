using System.Collections.Generic;
using Backend.Models;
using MongoDB.Driver;

namespace Backend.Services
{
  public class RolesService
  {
    private readonly IMongoCollection<Roles> _roles;

    public RolesService(IMeSafeDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _roles = database.GetCollection<Roles>(settings.RolesCollectionName);
    }

    public List<Roles> Get() =>
      _roles.Find(rol => true).ToList();

    public Roles Get(string id) =>
      _roles.Find<Roles>(rol => rol.Id == id).FirstOrDefault();
  }
}