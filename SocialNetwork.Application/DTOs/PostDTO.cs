using SocialNetwork.Domain.Entites;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Application.DTOs;

public class PostDTO : Entity
{
    public string? Title { get;  set; }
    public string? Description { get;  set; }
    public string? PostImageUrl { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedDate { get; set; } = DateTime.Now;

}
