using CapG.OMS.Exceptions;
using CapG.OMS.Models;
using CapG.OMS.Models.Dtos;
using CapG.OMS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapG.OMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderRepository repository;
        public OrdersController(IOrderRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IEnumerable<OrderInputDto> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public OrderInputDto Get(int id)
        {
            try
            {
                var list = repository.Get(id);
                return list;
            }
            catch (OmsException ex)
            {
                return null;
            }
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult Post(OrderInputDto order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (order.OrderItems.Any())
                    {
                        bool isAdded = repository.Add(order);
                        if (isAdded)
                            return Created("order", order);
                        else
                            return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured.");
                    }
                    else
                        return BadRequest("Atleast 1 item must be present.");
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, "Duplicate Product.");
            }
        }

        /*
        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                    return Ok("Order deleted successfully.");
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured.");
            }
            catch (OmsException ex)
            {
                return NotFound();
            }
        }
        */

        [HttpPost("{id}")]
        public ActionResult Cancel(int id)
        {
            try
            {
                var isCanceled = repository.Cancel(id);
                if (isCanceled)
                {
                    return Ok("Order Canceled Successfully");
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured");

            }
            catch (OmsException ex)
            {
                //exception filter
                if (ex.Message == "Order not found")
                {
                    return NotFound(ex.Message);
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured");
            }
        }
    }
}
