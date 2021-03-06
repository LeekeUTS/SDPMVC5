﻿using System;
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

        public DbSet<Attendance> Attendence { get; set; }
        public DbSet<Reminder> Reminder { get; set; }
        public DbSet<Waiting> Waitings { get; set; }

        //public System.Data.Entity.DbSet<SDP_MVC5.Models.Waiting> Waitings { get; set; }
    }
}