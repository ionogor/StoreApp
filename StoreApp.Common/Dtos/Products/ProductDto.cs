using StoreApp.Domain.Entity;
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
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Title is too short")]
        public string Title { get; set; } = default;

        [StringLength(100, MinimumLength = 20)]
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? PhotoPath { get; set; }
        public string CatalogName{ get; set; }
        public int SupplierId { get; set; }
    }
}
