using Microsoft.EntityFrameworkCore;
using ProductsAPIForTechGig.Models.Domain;

namespace ProductsAPIForTechGig.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
