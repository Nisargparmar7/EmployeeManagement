using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for your models
        public DbSet<UserModel> Users { get; set; }
        public DbSet<JobModel> Jobs { get; set; }
        public DbSet<AllocationModel> Allocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API configurations (if needed)
            base.OnModelCreating(modelBuilder);
        }
    }
}
