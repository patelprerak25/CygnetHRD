using CygnetHRD.Application.Interfaces;
using CygnetHRD.Entity.Entities;
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

namespace CygnetHRD.WebAPI.Controllers
{
    /// <summary>
    /// Login contoller class to provide Login feature which can create token and send back to user.
    /// Also provide feature of validation of token send by user.
    /// </summary>
    [Route("api/[Controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// Public constructor to initialize UnitOfWork instance.
        /// </summary>
        /// <param name="unitOfWork">IUnitOfWork</param>
        /// <param name="configuration">IConfiguration</param>
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            this.unitOfWork = unitOfWork;
            this.configuration = configuration;
        }

        /// <summary>
        /// This action method used for Login feature.
        /// It use User inforamtion and creates token and send back to user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public  IActionResult Login([FromBody] Login user)
        {
            if (user == null)
            {
                return this.BadRequest(new { status = 400, isSuccess = false, message = "Invalid request." });
            }

            User _user = this.unitOfWork.Users.GetAllAsync().Result.Where(a => a.Email == user.Email && a.Password == user.Password).FirstOrDefault();
            if (_user != null)
            {
                return this.Ok(new { status = 200, isSuccess = true, message = GenerateToken(user.Email) });
            }
            else
            {
                return this.Ok(new { status = 401, isSuccess = false, message = "Unauthorized user." });
            }
        }             

        /// <summary>
        /// Generate token on basis of given user information.
        /// </summary>
        /// <param name="username">string</param>
        /// <returns></returns>
        private string GenerateToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Name, username),              
            };

            var token = new JwtSecurityToken(this.configuration["Jwt:Issuer"],
                this.configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
