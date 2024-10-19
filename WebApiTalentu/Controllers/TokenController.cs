using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApiTalentu.Context;
using WebApiTalentu.Models;

namespace WebApiTalentu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IConfiguration _configuration; 

        public TokenController(IConfiguration configuration, AppDbContext context) 
        {
            _configuration = configuration;
            this.context = context;
        }


        [HttpPost]
        public IActionResult Authentication(UserLogin login)
        {
            // If it a valid user 
            if (IsValidUser(login)) 
            {
                var userInDb = context.Users.FirstOrDefault(f => f.Email == login.Email);
                var token = GenerateToken();
                return Ok(new { ok = true, uid=userInDb.IdUser, name= login.Email, token });
            }

            return NotFound("Usuario o contraseña incorrecta");
        }

        private bool IsValidUser(UserLogin login) {

            var userInDb = context.Users.FirstOrDefault(f => f.Email == login.Email);
            if (userInDb != null) {
            var isValidPassword = userInDb.Password == login.Password;
                if (isValidPassword)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;           
            }
        }

        private string GenerateToken() 
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Sergio Palacio"),
                new Claim(ClaimTypes.Email, "sergio@gmail.com"),
                new Claim(ClaimTypes.Role, "Administrador"),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header,payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
