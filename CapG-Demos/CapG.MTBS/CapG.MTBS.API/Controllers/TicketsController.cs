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
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository repository;
        public TicketsController(ITicketRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<TicketsController>
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<TicketsController>/5
        [HttpGet("{id}")]
        public Ticket Get(int id)
        {
            try
            {
                var customer = repository.Get(id);
                return customer;
            }
            catch (MtbsException ex)
            {
                return null;
            }
        }

        // POST api/<TicketsController>
        [HttpPost]
        [ValidateModel]
        public ActionResult Post(Ticket ticket)
        {
            try
            {
                bool isAdded = repository.Add(ticket);
                if (isAdded)
                {
                    return Created("ticket", ticket);
                }
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error while booking ticket.");
            }
            catch (MtbsException ex)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, ex.Message);
            }
        }

        // PUT api/<TicketsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpPost("{id}")]
        public ActionResult Cancel(int id)
        {
            try
            {
                var isCanceled = repository.Cancel(id);
                if (isCanceled)
                {
                    return Ok("Ticket Canceled Successfully");
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured");

            }
            catch (MtbsException ex)
            {
                //exception filter
                if (ex.Message == "Ticket not found")
                {
                    return NotFound(ex.Message);
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured");
            }
        }
    }
}
