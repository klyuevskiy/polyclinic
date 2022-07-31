using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using polyclinic.Models;

namespace polyclinic
{
     public class AppContext : DbContext
    {
        public DbSet<Operator> Operators { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Appeal> Appeals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=polyclinic.db");
        }
    }
}
