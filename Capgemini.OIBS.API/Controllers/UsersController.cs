using Capgemini.OIBS.API.Filters;
using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Capgemini.OIBS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capgemini.OIBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserRepository repository;
        OIBS_DBcontext context;
        public UsersController(UserRepository repository, OIBS_DBcontext context)
        {
            this.repository = repository;
            this.context = context;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                var user = repository.Get(id);
                return user;
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        [ValidateModel]
        public ActionResult Post(User entity)
        {
            try
            {
                bool isAdded = repository.Add(entity);
                if (isAdded)
                {
                    return Created("User", entity);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error while adding User");
                }
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut()]
        [ValidateModel]
        public ActionResult Put(User entity)
        {
            try
            {
                bool isUpdated = repository.Update(entity);
                if (isUpdated)
                {
                    return Ok("User Updated Successfully");
                }
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured");
            }
            catch (OIBSException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("verify/{id}")]
        [ValidateModel]
        [Authorize(Roles = ("Admin"))]
        public ActionResult Verify(int id)
        {
            try
            {
                var user = repository.Verify(id);
                if (user == true)
                {
                    return Ok("User Verified Successfully");
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Failed to verify User");
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
