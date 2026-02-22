using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
using Capgemini.OIBS.Models.DTOS;
using Capgemini.OIBS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capgemini.OIBS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        TransactionRepository repository;
        public TransactionsController(TransactionRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<TransactionsController>
        [HttpGet]
        [Authorize(Roles = ("Customer"))]
        public IEnumerable<Transaction> Get()
        {
            var exist = repository.Get();
            return exist;
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = ("Customer"))]
        public ActionResult<Transaction> Get(int id)
        {
            try
            {
                var exist = repository.Get(id);
                return exist;
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,ex.Message);
            }
        }

        // POST api/<TransactionsController>
        [HttpPost]
        [Authorize(Roles = ("Customer"))]
        public ActionResult Post(TransactionDTO entity)
        {
            try
            {
                if(entity.Amount < 100)
                {
                    return BadRequest("Minimum tranaction amount should be greater than 100");
                }
                bool isAdded = repository.Add(entity);
                if (isAdded)
                {
                    return Created("Transaction", entity);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error while adding Transaction");
                }
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        // GET api/<TransactionsController>/5
        [HttpGet("report/{id}")]
        [Authorize(Roles = ("Admin"))]
        public IEnumerable<ReportDTO> Report(int id)
        {
            var exist = repository.Report(id);
            return exist;
        }
    }
}
