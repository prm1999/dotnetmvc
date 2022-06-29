using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class AmbulanceDriver
    {
        public int AmbulanceDriverId { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "CNIC")]
        public string Cnic { get; set; }

        [ForeignKey("Patient")]
        public Patient Patient { get; set; }

    }
}