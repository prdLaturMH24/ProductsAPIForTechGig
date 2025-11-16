using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsAPIForTechGig.Models;
using ProductsAPIForTechGig.Models.Dal;
using ProductsAPIForTechGig.Models.Domain;
using ProductsAPIForTechGig.Repository;

namespace ProductsAPIForTechGig.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("Products")]
        public async Task<IActionResult> GetProductAsync()
        {
            List<ProductDal> productsDal = new List<ProductDal>();
            var products= await _productRepository.GetProductsAsync();
            if(products.Any())
            {
                foreach (var item in products)
                {
                    var productDal = _mapper.Map<ProductDal>(item);
                    productsDal.Add(productDal);
                }
                return Ok(productsDal);
            }
            return NoContent();
        }

        [HttpGet("Product/{product_id:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int product_id)
        {
            var product = await _productRepository.GetProductAsync(product_id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost("Product")]
        public async Task<IActionResult> AddProductAsync(ProductDal productDal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (String.IsNullOrEmpty(productDal.ProductName) || String.IsNullOrWhiteSpace(productDal.ProductName))
            {
                return BadRequest();
            }
            var addedProduct= await _productRepository.AddProductAsync(_mapper.Map<Product>(productDal));
            var item = _mapper.Map<ProductDal>(addedProduct);
            return Created($"/{addedProduct.Id}",item);
        }
        
        [HttpDelete("Product/{product_id:int}")]
        public async Task<ActionResult> DeleteProductAsync(int product_id)
        {
            Product product= await _productRepository.DeleteProductAsync(product_id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductDto>(product));
        }
    }
}
