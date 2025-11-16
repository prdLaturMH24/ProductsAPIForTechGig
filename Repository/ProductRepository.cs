using Microsoft.EntityFrameworkCore;
using ProductsAPIForTechGig.Data;
using ProductsAPIForTechGig.Models.Domain;

namespace ProductsAPIForTechGig.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
           _productDbContext = productDbContext;
        }

       public async Task<Product> AddProductAsync(Product product)
        {
             _productDbContext.Products.Add(product);
            await _productDbContext.SaveChangesAsync();
            return product;    
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            Product product= await _productDbContext.Products.FindAsync(id);
            if(product == null)
            {
                return product;
            }
            _productDbContext.Products.Remove(product);
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _productDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productDbContext.Products.ToListAsync(); 
        }

    }
}
