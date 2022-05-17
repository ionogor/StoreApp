﻿using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StoreApp.Common.Dtos.Users
{
    public class UserDto
    {
       
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool Type { get; set; } // 0 user 1 admin
        public string Email { get; set; }
        public int AddressId { get; set; }

    }
}
