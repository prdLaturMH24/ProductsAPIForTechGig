using AutoMapper;
using ProductsAPIForTechGig.Models;
using ProductsAPIForTechGig.Models.Dal;
using ProductsAPIForTechGig.Models.Domain;

namespace ProductsAPIForTechGig.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<Product,ProductDal>().ReverseMap();
        }
    }
}
