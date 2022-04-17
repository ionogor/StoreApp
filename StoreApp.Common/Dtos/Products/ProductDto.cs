using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Dtos.Products
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength (20,MinimumLength =3,ErrorMessage ="Title is too short")]
        public string Title { get; set; }

        [StringLength(100,MinimumLength = 20)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CatalogId { get; set; }
        public int SupplierId { get; set; }
    }
}
