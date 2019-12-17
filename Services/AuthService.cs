using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.DTO;
using Backend.Models;
using MongoDB.Driver;
using Backend.utils;

namespace Backend.Services
{
  public class AuthService
  {
    private readonly IMongoCollection<Usuarios> _usuarios;

    public AuthService(IMeSafeDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      _usuarios = database.GetCollection<Usuarios>(settings.UsersCollectionName);
    }

    public Usuarios Login(LoginDto loginDto) =>
      _usuarios.Find<Usuarios>(usuario => usuario.email == loginDto.email && usuario.password == loginDto.password).FirstOrDefault();

    public async Task<string> requestToken(LoginDto loginDto)
    {
      var client = new HttpClient();
      var parameters = new Dictionary<string, string> { { "client_id", loginDto.client_id }, { "grant_type", loginDto.grant_type }, { "scopes", loginDto.scopes }, { "client_secret", loginDto.client_secret } };
      var encodedContent = new FormUrlEncodedContent(parameters);

      var response = await client.PostAsync("http://cancerberus/connect/token", encodedContent).ConfigureAwait(false);
      var contents = await response.Content.ReadAsStringAsync();

      if(response.StatusCode == HttpStatusCode.OK) {
        return contents;
      }
      return "";
    }
  }
}