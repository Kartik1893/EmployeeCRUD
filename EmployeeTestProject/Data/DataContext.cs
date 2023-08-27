using EmployeeTestProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTestProject.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(x=> new {x.FirstName, x.LastName, x.Email})
                .IsUnique();
        }
    }
}
