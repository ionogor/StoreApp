using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class Catalog:BaseEntity
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public virtual List<Product> Products { get; set; }


    }
}
