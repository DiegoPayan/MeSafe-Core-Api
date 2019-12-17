using Backend.Models;

namespace Backend.DTO
{
  public class AuthDTo
  {

    public UsuariosDto usuario { get; set; }

    public Roles rol { get; set; }

    public string token { get; set; }

    public string extractToken(string token)
    {
      var splited = token.Split('"');
      return splited[3];
    }

  }
}