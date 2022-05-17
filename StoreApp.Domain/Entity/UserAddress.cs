using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Domain.Entity
{
    public class UserAddress
    {
        public User User { get; set; }
        public Address Address { get; set; }
    }
}
