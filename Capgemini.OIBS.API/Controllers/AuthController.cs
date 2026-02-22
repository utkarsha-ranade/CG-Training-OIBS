using Capgemini.OIBS.API.Filters;
using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Capgemini.OIBS.Models.DTOS;
using Capgemini.OIBS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capgemini.OIBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthRepository repository;
        OIBS_DBcontext context;
        public AuthController(IAuthRepository repository, OIBS_DBcontext context)
        {
            this.repository = repository;
            this.context = context;
        }

        // POST api/<AuthController>
        [HttpPost]
        
        public IActionResult Post(LoginDTO login)
        {
            try
            {
                string token = repository.Login(login);
                return Ok(new { Token = token });
            }
            catch (OIBSException ex)
            {

                return BadRequest("Login failed");
            }
        }

        // PUT api/<AuthController>/5
        [HttpPut("{UserName}")]
        [ValidateModel]
        public IActionResult Put(string UserName, LoginDTO login)
        {
            try
            {
                var user = context.Users.FirstOrDefault(ex => ex.UserName == login.UserName);
                if (user == null)
                {
                    return NotFound("User not found");
                }
                if (UserName != login.UserName)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Username mismatch");
                else
                {
                    bool isUpdated = repository.Update(login);

                    if (isUpdated)
                        return Ok("Updated");
                    else
                        return StatusCode((int)HttpStatusCode.InternalServerError, "error occured");
                }
            }
            catch (OIBSException ex)
            {
                if (ex.Message.Contains("Duplicate Found"))
                    return StatusCode((int)HttpStatusCode.Forbidden, ex.Message);
                if (ex.Message.Contains("User not found"))
                    return BadRequest(ex.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
