using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourApi.Models;

namespace TourApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public TouristAgencyDbContext Context { get; }

        public UsersController(TouristAgencyDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> u = Context.Users.ToList();
            return Ok(u);
        }

        [Route("api/[controller]/register")]
        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                if (Context.Users.Any(u => u.Login == user.Login)
                    || Context.Users.Any(u => u.Email == user.Email))
                {
                    return BadRequest("User with the same login or email already exists");
                }

                User newUser = new User
                {
                    Login = user.Login,
                    Password = user.Password,
                    Email = user.Email,
                    Birthdate = user.Birthdate,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MiddleName = user.MiddleName,

                };

                Context.Users.Add(newUser);
                Context.SaveChanges();

                return Ok("User registered successfully");
            }

            return BadRequest("Invalid user data");
        }

        [Route("api/[controller]/login")]
        [HttpPost]
        public IActionResult AuthenticateUser(LoginModel loginData)
        {
            var user = Context.Users.FirstOrDefault(u => u.Login == loginData.Login && u.Password == loginData.Password);

            if (user != null)
            {
                // Генерируем токен доступа и возвращаем его
                var token = GenerateToken(user.Id);
                return Ok(token);
            }

            return Unauthorized("Invalid login or password");
        }


        private string GenerateToken(int userId)
        {
            // Генерация токена
            var token = Guid.NewGuid().ToString();
            return token;
        }


    }


    
}
