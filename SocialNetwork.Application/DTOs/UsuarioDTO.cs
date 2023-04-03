
using System.Text.Json.Serialization;

namespace SocialNetwork.Application.DTOs;

public class UsuarioDTO
{ 
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? UserName { get; set; }
    public string? Location{ get; set; }
    [JsonIgnore]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
