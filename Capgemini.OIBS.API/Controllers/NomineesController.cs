using Capgemini.OIBS.API.Filters;
using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
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
    public class NomineesController : ControllerBase
    {
        IRepository<Nominee> repository;
        public NomineesController(IRepository<Nominee> repository)
        {
            this.repository = repository;
        }
        // GET: api/<NomineesController>
        [HttpGet]
        public IEnumerable<Nominee> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<NomineesController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = ("Customer"))]
        public ActionResult<Nominee> Get(int id)
        {
            try
            {
                var nominee = repository.Get(id);
                return nominee;
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<NomineesController>
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = ("Customer"))]
        public ActionResult Post(Nominee entity)
        {
            try
            {
                bool isAdded = repository.Add(entity);
                if (isAdded)
                {
                    return Created("Nominee", entity);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error while adding Nominee");
                }
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<NomineesController>/5
        [HttpPut("{id}")]
        [ValidateModel]
        [Authorize(Roles = ("Customer"))]
        public ActionResult Put(int id, Nominee entity)
        {
            try
            {
                if (id == entity.Id)
                {
                    bool isUpdated = repository.Update(entity);
                    if (isUpdated)
                    {
                        return Ok("Nominee Updated Successfully");
                    }
                    else
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured");
                }
            }
            catch (OIBSException ex)
            {
                return NotFound(ex.Message);
            }
            return BadRequest("Id do not match");
        }

        // DELETE api/<NomineesController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = ("Customer"))]
        public ActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                {
                    return Ok("Deleted Nominee");
                }
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured while deleting Nominee");
            }
            catch (OIBSException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
