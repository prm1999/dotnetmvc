using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hospital_Management_System.Models
{
    public class Complaint
    {
        public int ComplaintId { get; set; }
        [Required]
        public string Complain { get; set; }
        public string Reply { get; set; }
        public DateTime? ComplainDate { get; set; }
    }
}