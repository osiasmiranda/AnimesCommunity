using System.Collections.ObjectModel;

namespace SocialNetwork.Domain.Entites;

public class Profile : Entity
{

    public Profile()
    {
        Posts = new Collection<Post>();
    }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ImageProfileUrl { get; set; }
    public DateTime BirthOfDay { get; set; }
    public string? Bio { get; set; }
    public string? Location { get; set; }
    public string? PhoneNumber { get; set; }
    public ICollection<Post>? Posts { get; set; }

}
