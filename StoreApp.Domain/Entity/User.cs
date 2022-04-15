using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class User:BaseEntity
    {
        public int Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool Type { get; set; } // 0 user 1 admin
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
