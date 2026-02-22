using CapG.MTBS.API.Filters;
using CapG.MTBS.Exceptions;
using CapG.MTBS.Models.Dtos;
using CapG.MTBS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CapG.MTBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieRepository repository;
        public MoviesController(IMovieRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<MoviesController>
        [HttpGet]
        public IEnumerable<MovieDto> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public MovieDto Get(int id)
        {
            try
            {
                var list = repository.Get(id);
                return list;
            }
            catch (MtbsException ex)
            {
                return null;
            }
        }

        // GET api/<MoviesController>/5
        [HttpGet("cast/{id}")]
        public IActionResult GetCast(int id)
        {
            try
            {
                var list = repository.GetCast(id);
                return Ok(list);
            }
            catch (MtbsException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured");
            }
        }

        // POST api/<MoviesController>
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Admin")]
        public ActionResult Post(MovieDto movieDto)
        {
            try
            {
                if (!movieDto.ActorIds.Any())
                {
                    return BadRequest("Atleast 1 actor must be present");
                }
                bool isAdded = repository.Add(movieDto);
                if (isAdded)
                {
                    return Created("movie", movieDto);
                }
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured");
            }
            catch (MtbsException ex)
            {
                if (ex.Message == "Movie already exists")
                {
                    //duplicate
                    return StatusCode((int)HttpStatusCode.Conflict, ex.Message);
                }
                if (ex.Message.Contains("does not exist"))
                {
                    //actor does not exist
                    //director does not exist
                    return NotFound(ex.Message);
                }
                //sql
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
