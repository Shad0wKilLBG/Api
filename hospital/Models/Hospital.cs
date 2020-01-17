using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hospital.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        [Required]
        public string HospitalName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }
        public string WebAddress { get; set; }
    }
}
