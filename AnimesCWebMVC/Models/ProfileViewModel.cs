﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AnimesCWebMVC.Models
{
    public class ProfileViewModel

    {
        public string? Id { get; set; }

        [StringLength(20, MinimumLength = 3)]
        
        public string? FirstName { get; set; }

        [StringLength(20, MinimumLength = 3)]
        
        public string? LastName { get; set; }

        public string? ProfileImageUrl { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        
        public DateTime BirthOfDay { get; set; }

        public string? UserName { get; set; }
        public string? Email { get; set; }

        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public string? Bio { get; set; }
        public string? Location { get; set; }
        [JsonIgnore]
        public ICollection<PostViewModel>? Posts { get; set; }

    }
}
