using CapG.OMS.Exceptions;
using CapG.OMS.Models;
using CapG.OMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapG.OMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IRepository<Product> repository;
        public ProductsController(IRepository<Product> repository)
        {
            this.repository = repository;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            try
            {
                var product = repository.Get(id);
                return product;
            }
            catch (OmsException ex)
            {
                return null;
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isAdded = repository.Add(product);
                    if (isAdded)
                    {
                        return Created("product", product);
                    }
                    else
                        return StatusCode((int)HttpStatusCode.InternalServerError, "Error while adding product.");
                }
                catch (OmsException ex)
                {
                    return StatusCode((int)HttpStatusCode.Forbidden, ex.Message);
                }
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                if (id == product.Id)
                {
                    try
                    {
                        bool isUpdated = repository.Update(product);
                        if (isUpdated)
                            return Ok("Product Updated");
                        else
                            return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured.");
                    }
                    catch (OmsException ex)
                    {
                        return NotFound();
                    }
                }
                return BadRequest("IDs do not match");
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                    return Ok("Product deleted successfully.");
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error occured.");
            }
            catch (OmsException ex)
            {
                return NotFound();
            }
        }
    }
}
