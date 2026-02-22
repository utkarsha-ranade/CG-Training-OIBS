using CapG.OMS.Models;
using CapG.OMS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using CapG.OMS.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace CapG.OMS.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OMSContext context;
        private readonly IConfiguration config;

        public UserRepository(OMSContext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        public string Login(LoginDto login)
        {
            try
            {
                var user = context.Users.FirstOrDefault(u =>
                            u.Username == login.Username &&
                            u.Password == login.Password);
                if (user == null)
                {
                    throw new OmsException("Login failed");
                }
                //jwt token
                var token = GenerateJSONWebToken(user);
                return token;
            }
            catch (SqlException ex)
            {
                throw new OmsException(ex.Message);
            }
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["Jwt:Issuer"],
              config["Jwt:Issuer"],
              new List<Claim>
              {
                  new Claim("id", userInfo.Id.ToString()),
                  new Claim("role", userInfo.Role.ToString())
              },
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
