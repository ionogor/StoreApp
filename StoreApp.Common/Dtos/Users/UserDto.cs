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

        [JsonIgnore]
        public string Password { get; set; }
   
        public string PhoneNumber { get; set; }
        public bool Type { get; set; } // 0 user 1 admin

    }
}
