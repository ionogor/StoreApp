using StoreApp.Common.Dtos.Products;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Dtos.Catalogs
{
    public class CatalogDto
    {
   
       public int Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public List<ProductDto> Products { get; set; }
       // public List<Photo> Photos { get; set; }

    }
}
