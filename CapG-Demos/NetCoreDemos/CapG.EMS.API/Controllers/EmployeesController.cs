using CapG.EMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapG.EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        static List<Employee> list = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Sam",
                DateofJoining = new DateTime(2020,1,10),
                Email = "sam1212@gmail.com",
                Salary = 25000,
                DeptId = 1001,
                MobileNo = 9876543210
            },
            new Employee
            {
                Id = 2,
                Name = "Sid",
                DateofJoining = new DateTime(2019,2,20),
                Email = "sid0000@gmail.com",
                Salary = 25000,
                DeptId = 1001,
                MobileNo = 9988776655
            }
        };
        static int counter = 3;

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return list;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            Employee employee = list.Find(e => e.Id == id);
            return employee;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult Post([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                //duplicate scenario
                var existingProduct = list.Find(e => e.Name == employee.Name && e.Email == employee.Email && e.MobileNo == employee.MobileNo);
                if (existingProduct != null)
                {
                    //return Forbid();
                    return StatusCode((int)HttpStatusCode.Forbidden, "Duplicate Product");
                }

                employee.Id = counter;
                counter++;
                list.Add(employee);
                return Created("product", employee);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (id == employee.Id)
                {
                    var existingProduct = list.Find(e => e.Id == employee.Id);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }
                    existingProduct.Name = employee.Name;
                    existingProduct.DateofJoining = employee.DateofJoining;
                    existingProduct.Email = employee.Email;
                    existingProduct.Salary = employee.Salary;
                    existingProduct.DeptId = employee.DeptId;
                    existingProduct.MobileNo = employee.MobileNo;
                    return Ok("Product Updated Successfully.");
                }
                return StatusCode((int)HttpStatusCode.BadRequest, "Product ids do not match");
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var employee = list.Find(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                list.Remove(employee);
                counter--;
                return Ok("Successfully Deleted.");
            }
        }
    }
}
