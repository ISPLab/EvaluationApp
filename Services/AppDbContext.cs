using Microsoft.EntityFrameworkCore;

namespace App;

public class AppDbContext : DbContext
{
        public DbSet<User> Users { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=evalution;User Id=sa;Password=Giraffe#LemonTree88; Encrypt=false;TrustServerCertificate=true;");
        }
}