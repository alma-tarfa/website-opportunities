using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpportunitiesDraft1.Models
{
    public class BAME
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string BusinessName { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Statement cannot exceed 200 characters")]
        public string Statement { get; set; }

        [Required]
        [MaxLength(600, ErrorMessage = "Details can't exceed 600 characters")]
        public string Description { get; set; }

        public string WebsiteLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string PhotoPath { get; set; }
    
    }
}
