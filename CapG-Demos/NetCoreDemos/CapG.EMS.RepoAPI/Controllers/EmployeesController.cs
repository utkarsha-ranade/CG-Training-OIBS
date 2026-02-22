using CapG.EMS.Exceptions;
using CapG.EMS.Models;
using CapG.EMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapG.EMS.RepoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository repository;
        public EmployeesController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            try
            {
                var emp = repository.Get(id);
                return emp;
            }
            catch (EmsException ex)
            {
                return null;
            }
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isAdded = repository.Add(employee);
                    if (isAdded)
                    {
                        return Created("employee", employee);
                    }
                    else
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Error while adding employee.");
                }
                catch (EmsException ex)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, ex.Message);
                }
            }
            return BadRequest(ModelState);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id == employee.Id)
                {
                    try
                    {
                        bool isUpdated = repository.Update(employee);
                        if (isUpdated)
                            return Ok("Employee Updated");
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

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                    return Ok("Employee deleted successfully.");
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured.");
            }
            catch (EmsException ex)
            {
                return NotFound();
            }
        }

        // GET api/<EmployeesController>/department/5
        [HttpGet("department/{id}")]
        public ActionResult GetByDepartment(int id)
        {
            var list = repository.GetByDept(id);
            return Ok(list);
        }
    }
}
