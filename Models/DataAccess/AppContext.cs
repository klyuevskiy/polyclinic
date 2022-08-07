using Microsoft.EntityFrameworkCore;
using Models.DataModels;

namespace Models.DataAccess
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
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=polyclinic.db");
        }
    }
}
