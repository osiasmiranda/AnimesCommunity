using SocialNetwork.Domain.Entites;
using System.ComponentModel.DataAnnotations;
namespace SocialNetwork.Application.DTOs;

public class ProfileDTO : Entity
{
    [StringLength(20, MinimumLength = 3)]
    [Required(ErrorMessage = "Este campo é obrigatorio")]
    public string? FirstName { get;  set; }

    [StringLength(20, MinimumLength = 3)]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public string? LastName { get; set; }

    public string? ImageProfileUrl { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    public DateTime BirthOfDay { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
    public string? Bio { get; set; }

    public string? Location { get; set; }

    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }
    public ICollection<Post>? Posts { get; set; }
}
