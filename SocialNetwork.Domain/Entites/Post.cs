using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SocialNetwork.Domain.Entites;

public class Post
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get;  set; }
    public string? PostImageUrl { get;  set; }
    public DateTime CreatedAt { get;  set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public string AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    [JsonIgnore]
    public Profile? Author { get; set; }


}
