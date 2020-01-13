using AutoMapper;
using ProductCatalogApp.API.Dtos;
using ProductCatalogApp.API.Models;

namespace ProductCatalogApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductForCreateDto, Product>();
        }
    }
}