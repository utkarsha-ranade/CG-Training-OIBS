using CapG.EMS.Exceptions;
using CapG.EMS.Models;
using CapG.EMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapG.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IRepository<Departments> repository;
        public DepartmentsController(IRepository<Departments> repository)
        {
            this.repository = repository;
        }
        // GET: api/<DepartmentsController>
        [HttpGet]
        public IEnumerable<Departments> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public Departments Get(int id)
        {
            try
            {
                var dept = repository.Get(id);
                return dept;
            }
            catch (EmsException ex)
            {
                return null;
            }
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public ActionResult Post(Departments departments)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isAdded = repository.Add(departments);
                    if (isAdded)
                    {
                        return Created("department", departments);
                    }
                    else
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Error while adding department.");
                }
                catch (EmsException ex)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, ex.Message);
                }
            }
            return BadRequest(ModelState);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Departments departments)
        {
            if (ModelState.IsValid)
            {
                if (id == departments.Id)
                {
                    try
                    {
                        bool isUpdated = repository.Update(departments);
                        if (isUpdated)
                            return Ok("Department Updated");
                        else
                            return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured.");
                    }
                    catch (EmsException ex)
                    {
                        return NotFound();
                    }
                }
                return BadRequest("IDs do not match");
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                    return Ok("Department deleted successfully.");
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured.");
            }
            catch (EmsException ex)
            {
                return NotFound();
            }
        }
    }
}
