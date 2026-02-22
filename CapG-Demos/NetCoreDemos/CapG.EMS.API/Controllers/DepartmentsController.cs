using CapG.EMS.Models;
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
        static List<Department> list = new List<Department>
        {
            new Department
            {
                Id = 1001,
                Name = "HRDept"
            },
            new Department
            {
                Id = 1002,
                Name = "ITDept"
            }
        };
        static int counter = 3;
        // GET: api/<DepartmentsController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return list;
        }

        // GET api/<DepartmentsController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            Department department = list.Find(d => d.Id == id);
            return department;
        }

        // POST api/<DepartmentsController>
        [HttpPost]
        public ActionResult Post([FromForm] Department department)
        {
            if (ModelState.IsValid)
            {
                //duplicate scenario
                var existingProduct = list.Find(d => d.Name == department.Name);
                if (existingProduct != null)
                {
                    //return Forbid();
                    return StatusCode((int)HttpStatusCode.Forbidden, "Duplicate Product");
                }

                department.Id = counter;
                counter++;
                list.Add(department);
                return Created("product", department);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<DepartmentsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] Department department)
        {
            if (ModelState.IsValid)
            {
                if (id == department.Id)
                {
                    var existingProduct = list.Find(d => d.Id == department.Id);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }
                    existingProduct.Name = department.Name;
                    return Ok("Product Updated Successfully.");
                }
                return StatusCode((int)HttpStatusCode.BadRequest, "Product ids do not match");
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<DepartmentsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var department = list.Find(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            else
            {
                list.Remove(department);
                counter--;
                return Ok("Successfully Deleted.");
            }
        }
    }
}
