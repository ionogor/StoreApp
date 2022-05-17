using Microsoft.AspNetCore.Mvc;
using StoreApp.Common.Dtos.Users;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        Task<UserDto>AddUser(CreateUserDto userDto);
        Task<UserDto> GetById(int id);
    }
}
