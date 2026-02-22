using Capgemini.OIBS.API.Controllers;
using Capgemini.OIBS.Models;
using Capgemini.OIBS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using Xunit;

namespace OIBS.Unit.Tests
{
    public class AccountControllerUnitTest
    {
        AccountsController controller = null;
        public AccountControllerUnitTest()
        {
            var options = new DbContextOptionsBuilder<OIBS_DBcontext>()
                .UseSqlServer("Server=LAPTOP-S854AQV2;Database=OIBSDb;Trusted_Connection=True;").Options;
            OIBS_DBcontext context = new OIBS_DBcontext(options);
            AccountRepository repository = new AccountRepository(context);
            controller = new AccountsController(repository);

        }

        [Fact]
        public void Test_Post_NewAccount_ShoudReturnCreatedStatus()
        {
            Account acc = new Account
            {
                Balance = 15000,
                AccountNo = 1111111112,
                InterestAmount = 500,
                AccountType = type.Savings,
                UserId = 1
            };
            var result = controller.Post(acc) as CreatedResult;
            Assert.Equal((int)HttpStatusCode.Created, result.StatusCode.Value);
        }
    }
}
