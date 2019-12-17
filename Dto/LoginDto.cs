namespace Backend.DTO
{
  public class LoginDto
  {
    public string email { get; set; }
    
    public string password { get; set; }

    public string client_id { get; set; }

    public string grant_type { get; set; }

    public string scopes { get; set; }

    public string client_secret { get; set; }
  }
}