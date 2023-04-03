using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Domain.Entites;

public class Profile : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfileImageUrl { get; set; }
    public DateTime BirthOfDay { get; set; }
    public string? Bio { get; set; }
    public string? Location { get; set; }

    public ICollection<Post>? Posts { get; set; }
    public string? AccountId { get; set; }
    [Required]
    public string? Password { get; set; }

}
