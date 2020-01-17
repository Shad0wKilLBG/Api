using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Health_Condition { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int NurseId { get; set; }
        public Nurse Nurse { get; set; }
    }
}
