using Microsoft.EntityFrameworkCore;
using mvcTemplate.Models;
 
namespace mvcTemplate.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
         {
         }
    }
}