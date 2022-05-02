using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class Supplier:BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string HomePage { get; set; }
        public string Email { get; set; }
        // todo: add addressid
        public Address? Adress { get; set; } // Rename to Address
        public IEnumerable<Product> Products { get; set; }
    }
}
