using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialNetwork.Domain.Entites;

public sealed class Post : Entity
{

    public void Update(int profileId)
    {
        ProfileId = profileId;
    }
    public string? Title { get; set; }
    public string? Description { get;  set; }
    public string? ImageUrl { get;  set; }
    public DateTime CreatedAt { get;  set; }

    [ForeignKey("Profile")]
    public int ProfileId { get; set; }
    [JsonIgnore]
    public Profile? Profile { get; set; }


}
