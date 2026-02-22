using CapG.MTBS.Exceptions;
using CapG.MTBS.Models;
using CapG.MTBS.Models.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CapG.MTBS.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MTBSContext context;
        private readonly IConfiguration config;

        public UserRepository(MTBSContext context, IConfiguration config)
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
                    throw new MtbsException("Login failed");
                }
                //jwt token
                var token = GenerateJSONWebToken(user);
                return token;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
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
