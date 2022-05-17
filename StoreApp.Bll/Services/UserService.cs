using AutoMapper;
using BCrypt.Net;
using StoreApp.Bll.Interfaces;
using StoreApp.Common.Dtos.Users;
using StoreApp.Data.Interfaces;
using StoreApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace StoreApp.Bll.Services
{
    public class UserService 
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository,IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<UserDto> AddUser([FromBody] CreateUserDto userUpdateDto)
        {

            var newUser = new User()
            {
                Login=userUpdateDto.User.Login,
                Password=BCrypt.Net.BCrypt.HashPassword(userUpdateDto.User.Password),
                Email=userUpdateDto.User.Email,
                Type=userUpdateDto.User.Type
            };
            //var user = _mapper.Map<User>(userUpdateDto);
            _repository.Add(newUser);
            _repository.SaveChangeAsync();
            var userDto = _mapper.Map<UserDto>(newUser);

            return userDto;
        }



        public Task<UserDto> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser(int id, CreateUserDto userUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
