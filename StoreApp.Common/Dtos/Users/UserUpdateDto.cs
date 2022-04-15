using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Dtos.Users
{
    public class UserUpdateDto
    {
    
        [StringLength(10,MinimumLength =3)]
        public int Login { get; set; }

        [StringLength(10, MinimumLength = 8)]
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool Type { get; set; } // 0 user 1 admin
    }
}
