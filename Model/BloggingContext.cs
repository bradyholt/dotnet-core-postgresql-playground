using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace playground
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            optionsBuilder.UseNpgsql(config.GetConnectionString("Default"));
        }
    }
}
