using ConnectHealthApi.Data.Mapping;
using ConnectHealthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectHealthApi.Data
{
    public class ConnectHealthContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; } = null!;
        public DbSet<ProfessionalModel> Professionals { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=Server;Database=Database;User ID=sa;Password=Password;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProfessionalMap());
        }
    }
}