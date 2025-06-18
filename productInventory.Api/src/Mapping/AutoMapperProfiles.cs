using AutoMapper;
using ProductInventory.Api.Data;
using ProductInventory.Api.Data.DTOs;
using ProductInventory.Api.Models.Products;
using ProductInventory.Api.Models.Requests;

namespace ProductInventory.Api.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Products, ProductDto>().ReverseMap();
        CreateMap<CreateProductRequest, Products>();
        CreateMap<UpdateProductRequest ,Products>();
    }
}