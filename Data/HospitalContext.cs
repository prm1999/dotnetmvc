using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.Models;

namespace Hospital.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext (DbContextOptions<HospitalContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital_Management_System.Models.Doctor> Doctor { get; set; }

        public DbSet<Hospital_Management_System.Models.Patient> Patient { get; set; }

        public DbSet<Hospital_Management_System.Models.Department> Department { get; set; }

        public DbSet<Hospital_Management_System.Models.Reviews> Reviews { get; set; }

        public DbSet<Hospital_Management_System.Models.Schedule> Schedule { get; set; }

        public DbSet<Hospital_Management_System.Models.Medicine> Medicine { get; set; }

        public DbSet<Hospital_Management_System.Models.Prescription> Prescription { get; set; }

        public DbSet<Hospital_Management_System.Models.AmbulanceDriver> AmbulanceDriver { get; set; }

        public DbSet<Hospital_Management_System.Models.Ambulance> Ambulance { get; set; }

        public DbSet<Hospital_Management_System.Models.Announcement> Announcement { get; set; }

        public DbSet<Hospital_Management_System.Models.Appointment> Appointment { get; set; }
    }
}
