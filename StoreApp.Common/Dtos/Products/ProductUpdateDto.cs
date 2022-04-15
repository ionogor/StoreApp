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

        public string Title { get; set; }
        [Required]
        [StringLength(200,MinimumLength =10)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
