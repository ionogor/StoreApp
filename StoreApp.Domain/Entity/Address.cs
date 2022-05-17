using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class Address:BaseEntity
    {
        public string AddressLocation { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        //public IEnumerable<Supplier> Suppliers { get; set; }
        //public IEnumerable<User> Users { get; set; }


    }
}
