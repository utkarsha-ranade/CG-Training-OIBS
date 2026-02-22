using Capgemini.OIBS.API.Controllers;
using Capgemini.OIBS.Models;
using Capgemini.OIBS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace OIBS.Unit.Tests
{
    public class UserControllerUnitTest
    {
        UsersController controller = null;
        public UserControllerUnitTest()
        {
            var options = new DbContextOptionsBuilder<OIBS_DBcontext>()
                .UseSqlServer("Server=LAPTOP-S854AQV2;Database=OIBSDb;Trusted_Connection=True;").Options;
            OIBS_DBcontext context = new OIBS_DBcontext(options);
            UserRepository repository = new UserRepository(context);
            controller = new UsersController(repository, context);
        }

        [Fact]
        public void Test_Post_NewUser_ShoudReturnCreatedStatus()
        {
            User user = new User
            {
                UserName = "Admin",
                Password = "1234",
                Role = role.Admin,
                Name = "Administrator",
                DateOfBirth = Convert.ToDateTime("2000-01-02"),
                Gender = gender.Male,
                MobileNo = 8907113564,
                Email = "a@z.com",
                IsVerified = true
            };
            var result = controller.Post(user) as CreatedResult;
            Assert.Equal((int)HttpStatusCode.Created, result.StatusCode.Value);
        }
    }
}
