using AutoMapper;
using LearnASP.Dtos.Category;
using LearnASP.Dtos.Product;
using LearnASP.Dtos.User;
using LearnASP.Models;

namespace LearnASP.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}