using ProductsAPIForTechGig.Models.Domain;

namespace ProductsAPIForTechGig.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task<Product> AddProductAsync(Product product);
        Task<Product> DeleteProductAsync(int id);
    }
}
