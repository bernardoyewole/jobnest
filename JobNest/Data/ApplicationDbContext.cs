using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobNest.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=JobNest;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<ApplicationUser> Users { get; set; }
        //public DbSet<Job> Jobs { get; set; }
        //public DbSet<Application> Applications { get; set; }
    }
}
