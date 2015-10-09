using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SDP_MVC5.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Attendance> Attendence { get; set; }
        public DbSet<Reminder> Reminder { get; set; }
    }
}