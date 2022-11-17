using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.ViewModels
{
    public class RegisterViewModelPartner
    {
      
        public string UserType { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name can't exceed 50 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name can't exceed 50 characters")]
        public string Company { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        [Display(Name = "Office Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

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
        [MaxLength(600, ErrorMessage = "Additional message can't exceed 600 characteres")]
        public string AdditionalMessage { get; set; }
        public IFormFile Photo { get; set; }
    }
}
