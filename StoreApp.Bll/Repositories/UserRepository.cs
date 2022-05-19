using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Address;
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

        public async Task<UserDto> AddUser([FromBody]CreateUserDto userDto)
        {
           

            using (IDbContextTransaction transaction = _context.Database.BeginTransaction())
            {
               
                try
                {
                    Address address = mapper.Map<Address>(userDto.Address);
                    _context.Addresses.Add(address);

                    await _context.SaveChangesAsync();

                    User user = mapper.Map<User>(userDto.User);
                    user.Password=BCrypt.Net.BCrypt.HashPassword(userDto.User.Password);
                    user.AddressId=address.Id;
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    transaction.Commit();

                }
                catch (Exception)
                {

                    transaction.Rollback();
                }
            }


            return userDto.User;
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
