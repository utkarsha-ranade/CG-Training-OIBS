using Capgemini.OIBS.API.Filters;
using Capgemini.OIBS.Exceptions;
using Capgemini.OIBS.Models;
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
    public class AccountsController : ControllerBase
    {
        private IRepository<Account> repository;
        public AccountsController(IRepository<Account> repository)
        {
            this.repository = repository;
        }
        // GET: api/<AccountsController>
        [HttpGet]
        [Authorize(Roles = ("Admin"))]
        public IEnumerable<Account> Get()
        {
            var list = repository.Get();
            return list;
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = ("Admin"))]
        public ActionResult<Account> Get(int id)
        {
            try
            {
                var account = repository.Get(id);
                return account;
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<AccountsController>
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = ("Customer"))]
        public ActionResult Post(Account account)
        {
            try
            {
                bool isAdded = repository.Add(account);
                if (isAdded)
                {
                    return Created("Account", account);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error while Adding Account");
                }
            }
            catch (OIBSException ex)
            {
                return StatusCode((int)HttpStatusCode.Forbidden, ex.Message);
            }
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        [ValidateModel]
        [Authorize(Roles = ("Customer"))]
        public ActionResult Put(int id, Account account)
        {
            try
            {
                bool isUpdated = repository.Update(account);
                if (isUpdated)
                {
                    return Ok("Account Details Updated!!!!");
                }
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured while Updating Account");
            }
            catch (OIBSException ex)
            {

                return NotFound(ex.Message);
            }
        }
       
        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = ("Customer"))]
        public ActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = repository.Delete(id);
                if (isDeleted)
                {
                    return Ok("Deleted Account");
                }
                else
                    return StatusCode((int)HttpStatusCode.InternalServerError, "Error Occured while deleting Account");
            }
            catch (OIBSException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
