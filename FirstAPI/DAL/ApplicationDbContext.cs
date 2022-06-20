using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        
        public DbSet<Product> Products { get; set; }
    }
}
