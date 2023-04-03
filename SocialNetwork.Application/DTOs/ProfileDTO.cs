using Microsoft.AspNetCore.Identity;
using SocialNetwork.Domain.Entites;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialNetwork.Application.DTOs;

public class ProfileDTO 
{

   public string? Id { get; set; }
    public string? FirstName { get;  set; }

    [StringLength(20, MinimumLength = 3)]
    
    public string? LastName { get; set; }

    public string? ProfileImageUrl { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime BirthOfDay { get; set; }

    [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
    public string? Bio { get; set; }

    public string? Location { get; set; }

    public string? AccountId { get; set; }
}
