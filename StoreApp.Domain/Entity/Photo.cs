using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class Photo:BaseEntity
    {
        [Required]
        public string? Url { get; set; }
        public int ProductId { get; set; }
        public bool IsPrimary { get; set; }
        public virtual Product? Product { get; set; }
    }
}
