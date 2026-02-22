using CapG.MTBS.API.Filters;
using CapG.MTBS.Exceptions;
using CapG.MTBS.Models;
using CapG.MTBS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapG.MTBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepository<Customer> repository;
        public CustomersController(IRepository<Customer> repository)
        {
            this.repository = repository;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            try
            {
                var customer = repository.Get(id);
                return customer;
            }
            catch(MtbsException ex)
            {
                return null;
            }
        }

        // POST api/<CustomersController>
        [HttpPost]
        [ValidateModel]
        public ActionResult Post(Customer customer)
        {
            try
            {
                bool isAdded = repository.Add(customer);
                if (isAdded)
                {
                    return Created("customer", customer);
                }
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error while adding customer.");
            }
            catch (MtbsException ex)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, ex.Message);
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        [ValidateModel]
        public ActionResult Put(int id, Customer customer)
        {
            if (id == customer.Id)
            {
                try
                {
                    bool isUpdated = repository.Update(customer);
                    if (isUpdated)
                        return Ok("Customer Updated");
                    else
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured.");
                }
                catch (MtbsException ex)
                {
                    return NotFound();
                }
            }
            return BadRequest("IDs do not match");
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                    return Ok("Customer deleted successfully.");
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured.");
            }
            catch (MtbsException ex)
            {
                return NotFound();
            }
        }
    }
}
