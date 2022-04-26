using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Common.Dtos.Users;
using StoreApp.Domain.Entity;
using System.Security.Cryptography;
using StoreApp.Data.Interfaces;
using AutoMapper;
using StoreApp.Bll.Interfaces;
using StoreApp.Helpers;

namespace StoreApp.Controllers
{
    [Route("/login")]
    [ApiController]
    public class AccountController : Controller
    {

        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public AccountController(IUserRepository repo, JwtService jwtService)
        {
            _userRepository=repo;
            _jwtService=jwtService;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register(CreateUserDto userDto)
        {
            var user = _userRepository.AddUser(userDto);


            return Created("Created", user.Result);
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userRepository.GetByEmail(dto.Email);

            if (user == null)
            {
                return BadRequest(new { message = "Invalid user" });
            }
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message = "Invalid password" });
            }

            var jwtToken = _jwtService.GenerateToken(user.Id);

            Response.Cookies.Append("jwt", jwtToken, new CookieOptions
            {
                HttpOnly = true
            });

            return Ok(new
            {
                message = "succes"
            });
        }

        [HttpGet("user")]

        public IActionResult GetUser()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);
                int idUser = int.Parse(token.Issuer);

                var user = _userRepository.GetById(idUser);

                return Ok(user);

            }
            catch (Exception ex)
            {
              return Unauthorized();
            }

        }

        [HttpPost("logout")]

        public IActionResult LogOut()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                mess = "Logout"
            });
        }


    }
}
