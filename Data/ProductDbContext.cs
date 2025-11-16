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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Configure Product table explicitly
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProductName).IsRequired();
                entity.Property(e => e.Prize).HasPrecision(18, 2);
            });
        }
    }
}
