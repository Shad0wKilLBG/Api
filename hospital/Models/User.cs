using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hospital.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required!")]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
