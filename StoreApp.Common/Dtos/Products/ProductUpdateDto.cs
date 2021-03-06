using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Dtos.Products
{
    public class ProductUpdateDto
    {
        [Required]
        [StringLength(50,MinimumLength =3)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 20)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
