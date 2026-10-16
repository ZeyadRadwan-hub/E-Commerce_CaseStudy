using AutoMapper;
using E_Commerce_API.DTOs;
using E_Commerce_API.Models;

namespace E_Commerce_API.Mapping
{
    public class CatrgoryProfile: Profile
    {
        public CatrgoryProfile()
        {
            CreateMap<Category, CategoryResponeDTO>();
            CreateMap<CategoryDTO, Category>();
        }
    }
}
