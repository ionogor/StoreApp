using AutoMapper;
using StoreApp.Common.Dtos.Catalogs;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Profiles
{
    public class CatalogProfile:Profile
    {
        public CatalogProfile()
        {
            CreateMap<Catalog, CatalogDto>();
            CreateMap<CreateCatalogDto, Catalog>();
            CreateMap<Catalog, CreateCatalogDto>();

        }
     
    }
}
