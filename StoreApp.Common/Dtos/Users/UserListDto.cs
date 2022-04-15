using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Dtos.Users
{
    public class UserListDto
    {
        public int UserId { get; set; }
        public int Login { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool Type { get; set; } // 0 user 1 admin
    }
}
