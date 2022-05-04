using AutoMapper;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Users;
using StoreApp.Data.Context;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Bll.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GlobalContext _context;

        private readonly IMapper mapper;

        public UserRepository(GlobalContext context, IMapper mapper)
        {
            this._context = context;
            this.mapper=mapper;

        }

        public async Task<UserDto> AddUser(CreateUserDto userDto)
        {
            var user = new User
            {
                Login = userDto.Login,
                Password =BCrypt.Net.BCrypt.HashPassword(userDto.Password),
                Email = userDto.Email,
                IsAdmin=userDto.Type,
                PhoneNumber=userDto.PhoneNumber,


            };

            _context.Add(user);
            _context.SaveChanges();

            var userDtos = mapper.Map<UserDto>(user);

            return userDtos;
        }

        public async Task<User> GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email==email);

        }

        public async Task<UserDto> GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id==id);
            var userDto = mapper.Map<UserDto>(user);

            return userDto;
        }
    }
}
