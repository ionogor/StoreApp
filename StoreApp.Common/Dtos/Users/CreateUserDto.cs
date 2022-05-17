using StoreApp.Common.Dtos.Address;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Common.Dtos.Users
{
    public class CreateUserDto
    {

        //[StringLength(10, MinimumLength = 3)]
        //public string Login { get; set; }

        //[StringLength(10, MinimumLength = 8)]
        //public string Password { get; set; }
        //public string PhoneNumber { get; set; }
        //public string Email { get; set; }
        //public bool IsAdmin { get; set; } // 0 user 1 admin
        public  AddressDto Address { get; set; }
        public  UserDto User { get; set; }

    }
}
