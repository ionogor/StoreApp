using StoreApp.Common.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id);
        Task<IEnumerable<UserDto>> GetUsers();
        Task<UserDto> CreateUser(UserUpdateDto userUpdateDto);

        Task UpdateUser(int id, UserUpdateDto userUpdateDto);
        Task UpdateUser(int id);
    }
}
