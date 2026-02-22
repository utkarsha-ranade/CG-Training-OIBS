using CapG.ProductAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapG.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static List<Product> list = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Book",
                Category = Category.Stationery,
                MfgDate = new DateTime(2020,1,19),
                Price = 6000

            },
            new Product
            {
                Id = 2,
                Name = "HP Laptop",
                Category = Category.Electronics,
                MfgDate = new DateTime(2020,6,19),
                Price = 3000
            }
        };
        static int counter = 3;

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return list;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            Product product = list.Find(p => p.Id == id);
            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult Post([FromForm] Product product)
        {
            if (ModelState.IsValid)
            {
                //duplicate scenario
                var existingProduct = list.Find(p=> p.Name == product.Name && p.Price == product.Price && p.Category == product.Category);
                if (existingProduct != null)
                {
                    //return Forbid();
                    return StatusCode((int)HttpStatusCode.Forbidden, "Duplicate Product");
                }

                product.Id = counter;
                counter++;
                list.Add(product);
                return Created("product", product);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromForm] Product product)
        {
            if (ModelState.IsValid)
            { 
                if (id == product.Id)
                {
                    var existingProduct = list.Find(p => p.Id == product.Id);
                    if (existingProduct == null)
                    {
                        return NotFound();
                    }
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                    existingProduct.MfgDate = product.MfgDate;
                    existingProduct.Category = product.Category;
                    return Ok("Product Updated Successfully.");
                }
                return StatusCode((int)HttpStatusCode.BadRequest, "Product ids do not match");
            }
            return BadRequest(ModelState);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = list.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                list.Remove(product);
                return Ok("Successfully Deleted.");
            }         
        }
    }
}
