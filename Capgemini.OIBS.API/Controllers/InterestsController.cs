using Capgemini.OIBS.API.Filters;
using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Capgemini.OIBS.Models.DTOS;
using Capgemini.OIBS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capgemini.OIBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        InterestRepository repository;
        OIBS_DBcontext context;
        public InterestsController(InterestRepository repository, OIBS_DBcontext context)
        {
            this.repository = repository;
            this.context = context;
        }
        // GET: api/<InterestsController>
        [HttpGet]
        [Authorize(Roles = ("Admin"))]
        public IEnumerable<Interest> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<InterestsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = ("Admin"))]
        public ActionResult<Interest> Get(int id)
        {
            try
            {
                var interest = repository.Get(id);
                return interest;
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<InterestsController>/5
        [HttpPut("{id}")]
        [ValidateModel]
        [Authorize(Roles = ("Admin"))]
        public ActionResult Put(int id, InterestDTO entity)
        {
            var interest = context.Interests.Find(id);
            if(interest == null)
            {
                return NotFound("Interest Entry does not Exist");
            }
            if(interest.AccountNo == entity.AccountNo)
            {
                try
                {
                    bool isUpdated = repository.Update(entity);
                    if (isUpdated)
                    {
                        return Ok("Interest Details Updated!!!!");
                    }
                    else
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured while Updating Interest");
                }
                catch (OIBSException ex)
                {
                    return NotFound(ex.Message);
                }
            }
            else
            {
                return BadRequest("Account Numbers do not match");
            }
        }
    }
}
