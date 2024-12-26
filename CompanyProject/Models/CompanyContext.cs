using Microsoft.EntityFrameworkCore;

namespace CompanyProject.Models
{
    public class CompanyContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GhalySamir ;Database=CompanyG7;Trusted_Connection=True;TrustServerCertificate=True ");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> user_Roles { get; set; }

    }
}
