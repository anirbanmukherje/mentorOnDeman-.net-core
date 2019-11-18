using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorOnDemand.Dtos
{
    public class RegisterDto
    {
        [Required]
        
        public string FirstName{ get; set; }
        [Required]
        
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH",
            MinimumLength = 6)]
        public string Password { get; set; }
        public int Role { get; set; }
        public string Skill { get; set; }
        public string Experience { get; set; }
    }
}
