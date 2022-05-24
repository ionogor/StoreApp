using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StoreApp.Common.Dtos.Catalogs;
using StoreApp.Common.Dtos.Products;
using StoreApp.Domain.Entity;

namespace StoreApp.Common.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(x => x.PhotoPath, y => y.MapFrom(dest => dest.Photos.Url))
                .ForMember(x => x.CatalogName, y => y.MapFrom(des => des.Catalog.Name))
                .ForMember(x=>x.Reviews,y=>y.MapFrom(dest=>dest.Reviews));
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<Product, ProductListDto>();
            CreateMap<Product, CreateProductDto>().ForMember(x=>x.PhotoPath,y=>y.MapFrom(dest=>dest.Photos.Url)).ReverseMap();
            CreateMap<Product,ProductListDto>().ReverseMap();
        }
    }
}
