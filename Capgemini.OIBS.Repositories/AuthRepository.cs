using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Capgemini.OIBS.Models.DTOS;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Capgemini.OIBS.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        OIBS_DBcontext context;
        IConfiguration config;

        public AuthRepository(OIBS_DBcontext context, IConfiguration config)
        {
            this.context = context;
            this.config = config;
        }

        public string Login(LoginDTO login)
        {
            try
            {
                var existUser = context.Users.FirstOrDefault(u => u.UserName == login.UserName
                && u.Password == login.Password);
                if (existUser == null)
                {
                    throw new OIBSException("Login failed");
                }
                //JWT token
                var previousUser = context.Users.FirstOrDefault(ex=> ex.IsActive == true);
                if (previousUser != null)
                {
                    previousUser.IsActive = false;
                    context.Users.Update(previousUser);
                }
                var token = GenerateJSONWebToken(existUser);
                existUser.IsActive = true;
                context.Users.Update(existUser);
                context.SaveChanges();
                return token;
            }
            catch (SqlException ex)
            {

                throw new OIBSException(ex.Message);
            }
        }

        public bool Update(LoginDTO dto)
        {
            try
            {
                var Exist = context.Users.FirstOrDefault(ex => ex.UserName == dto.UserName);
                if (Exist == null)
                {
                    throw new OIBSException("User Does Not Exist");
                }
                Exist.Password = dto.Password;
                //context.Entry(entity).State = EntityState.Modified;
                context.Users.Update(Exist);

                if (context.SaveChanges() > 0)
                    return true;

                return false;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new OIBSException(ex.Message);
            }
            catch (SqlException ex)
            {
                throw new OIBSException(ex.Message);
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
                  new Claim("role",userInfo.Role.ToString())
              },
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
