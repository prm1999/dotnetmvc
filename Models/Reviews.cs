using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Reviews
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

     
        [EmailAddress]
        public string Email { get; set; }


        public string FindUs { get; set; }

        [Required]
        public string Message { get; set; }

        public Patient Patient { get; set; }
    }
}