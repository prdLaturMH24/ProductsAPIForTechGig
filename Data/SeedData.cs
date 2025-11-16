using Microsoft.EntityFrameworkCore;

namespace ProductsAPIForTechGig.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductDbContext(serviceProvider.GetRequiredService<
                DbContextOptions<ProductDbContext>>()))
            {
                if (context.Products.Any())
                {
                    return;  //DB has been seeded
                }

                context.Products.AddRange(
                    [new Models.Domain.Product
                    {
                        Id = 1,
                        ProductName = "Laptop",
                        ProductDescription = "Dell XPS 13",
                        Prize = 999.99M,
                        Category = "Electronics"
                    },
                    new Models.Domain.Product
                    {
                        Id = 2,
                        ProductName = "Smartphone",
                        ProductDescription = "iPhone 13",
                        Prize = 799.99M,
                        Category = "Electronics"
                    },
                    new Models.Domain.Product
                    {
                        Id = 3,
                        ProductName = "Headphones",
                        ProductDescription = "Sony WH-1000XM4",
                        Prize = 349.99M,
                        Category = "Electronics"
                    },
                    new Models.Domain.Product
                    {
                        Id = 4,
                        ProductName = "Coffee Maker",
                        ProductDescription = "Nespresso Vertuo",
                        Prize = 199.99M,
                        Category = "Home Appliances"
                    }
                    ]
                    );

                context.SaveChanges();
            }
        }
    }
}
