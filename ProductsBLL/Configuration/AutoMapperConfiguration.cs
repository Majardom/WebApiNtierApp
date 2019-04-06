using AutoMapper;
using BllEntities.DTO;
using DataEntities.Entities;

namespace ProductsBLL.Configuration
{
    public class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Supplier, SupplierDto>()
                    .ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.Id))
                    .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name))
                    .ForMember(destination => destination.Products, opt => opt.MapFrom(source => source.Products)).MaxDepth(1)
                    .ReverseMap();

                cfg.CreateMap<ProductCategory, ProductCategoryDto>()
                    .ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.Id))
                    .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name))
                    .ReverseMap();

                cfg.CreateMap<Product, ProductDto>()
                    .ForMember(destination => destination.Id, opt => opt.MapFrom(source => source.Id))
                    .ForMember(destination => destination.Name, opt => opt.MapFrom(source => source.Name))
                    .ForMember(destination => destination.Category, opt => opt.MapFrom(source => source.Category)).MaxDepth(1)
                    .ForMember(destination => destination.Supplier, opt => opt.MapFrom(source => source.Supplier)).MaxDepth(1)
                    .ReverseMap();
            });
        }
    }
}
