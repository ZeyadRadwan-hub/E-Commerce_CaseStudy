using AutoMapper;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;

namespace E_Commerce_API.Mapping
{
    public class ProductProfile:Profile
    {
        public ProductProfile() 
        {
            CreateMap<Product, ProductResponeDTO>();
            CreateMap<ProductCreateDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<ProductPatchDTO, Product>().ForAllMembers(
                w => w.Condition((x, y, z) => z != null));
        }
    }
}
