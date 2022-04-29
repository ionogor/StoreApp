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
            CreateMap<Product, ProductDto>();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
            CreateMap<Product, ProductListDto>();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product,ProductListDto>().ReverseMap();

            // Catalog Mapp

            CreateMap<Catalog,CatalogDto>();
          
            CreateMap<CreateCatalogDto, Catalog>();
            CreateMap<Catalog, CreateCatalogDto>();
           


        }
    }
}
