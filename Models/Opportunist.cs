using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public class Opportunist
    {
       
        public int Id { get; set; }
        [NotMapped]
        public string EncryptedId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "First Name can't exceed 50 characteres")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Last Name can't exceed 50 characteres")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public bool Mentorship { get; set; }
        public bool StartUp { get; set; }
        public bool Partnership { get; set; }
        public bool Sponsorship { get; set; }
        public bool BusinessOpportunities { get; set; }
        public bool AllyShip { get; set; }

        public bool WorkPlacement { get; set; }

        public bool JobOpportunities { get; set; }
        public bool WorkshopTraining { get; set; }
        [Required]
        [MaxLength(600, ErrorMessage = "Personal statement can't exceed 600 characteres")]
        public string PersonalStatement { get; set; }

        [Required]
        [MaxLength(600, ErrorMessage = "Additional message can't exceed 600 characteres")]
        public string AdditionalMessage { get; set; }
        public string PhotoPath { get; set; }
    }
}
