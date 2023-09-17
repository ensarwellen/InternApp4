using Microsoft.EntityFrameworkCore;

namespace InternApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Notes> Notes { get; set; }
    }
}
