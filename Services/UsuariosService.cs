using Backend.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System;
using MongoDB.Bson;

namespace Backend.Services
{
  public class UsuariosService
  {

    private readonly IMongoCollection<Usuarios> _usuarios;

    public UsuariosService(IMeSafeDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _usuarios = database.GetCollection<Usuarios>(settings.UsersCollectionName);
    }

    public List<Usuarios> Get() =>
      _usuarios.Find(usuario => true).ToList();

    public Usuarios Get(string id) =>
      _usuarios.Find<Usuarios>(usuario => usuario.Id == id).FirstOrDefault();

    public Usuarios Create(Usuarios usuario)
    {
      _usuarios.InsertOne(usuario);
      return usuario;
    }

    public void Update(string id, Usuarios usuarioIn)
    {
      _usuarios.ReplaceOne(usuario => usuario.Id == id, usuarioIn);
    }

    public void Remove(Usuarios usuarioIn) =>
      _usuarios.DeleteOne(usuario => usuario.Id == usuarioIn.Id);

    public void Remove(string id) =>
      _usuarios.DeleteOne(usuario => usuario.Id == id);
  }
}