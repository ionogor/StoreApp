using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class Review:BaseEntity
    {
        [Required]
        public string Comment { get; set; }
        public int NumStar { get; set; }
        public string VoteName { get; set; }
        // TODO: add product id 
        public virtual Product Product { get; set; }
    }
}
