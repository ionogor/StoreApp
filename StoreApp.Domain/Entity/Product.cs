using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class Product:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CatalogId { get; set; }
        // TODO: add Catalog Catalog {get;set;}
        public virtual IEnumerable<Photo> Photos { get; set; }
        public virtual IEnumerable<Review> Reviews { get; set; }

        public int SupplierId { get; set; }
       // public virtual Supplier? Supplier { get; set; }
       
    }
}
