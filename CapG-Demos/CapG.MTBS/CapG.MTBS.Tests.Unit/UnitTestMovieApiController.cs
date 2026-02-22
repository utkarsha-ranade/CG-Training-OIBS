using CapG.MTBS.API.Controllers;
using CapG.MTBS.Models;
using CapG.MTBS.Models.Dtos;
using CapG.MTBS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using Xunit;

namespace CapG.MTBS.Tests.Unit
{
    public class UnitTestMovieApiController
    {
        MoviesController controller = null;
        public UnitTestMovieApiController()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<MTBSContext>()
            .UseSqlServer("Server=LAPTOP-S854AQV2;Database=MtbsDb;Trusted_Connection=True;")
            .Options;
            MTBSContext context = new MTBSContext(options);
            MovieRepository repository = new MovieRepository(context);
            controller = new MoviesController(repository);
        }
        
        [Fact]
        public void Test_Post_NewMovie_ShoudReturnCreatedStatus()
        {
            //Arrange
            MovieDto movie = new MovieDto
            {
                Name = "Forest Gump",
                DirectorId = 2,
                Genre = Genre.Romance,
                ActorIds = new int[] { 3, 4 }
            };
            //Act
            var result = controller.Post(movie) as CreatedResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.Created, result.StatusCode.Value);
        }

        [Fact]
        public void Test_Post_DuplicateMovie_ShouldReturnForbiddenStatus()
        {
            //Arrange
            MovieDto movie = new MovieDto
            {
                Name = "Forest Gump",
                DirectorId = 2,
                Genre = Genre.Romance,
                ActorIds = new int[] { 3, 4 }
            };
            //Act
            var result = controller.Post(movie) as ConflictObjectResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.Conflict, result.StatusCode.Value);
        }

        [Fact]
        public void Test_Post_DirectorNotExists_ShouldReturnNotFoundStatus()
        {
            //Arrange
            MovieDto movie = new MovieDto
            {
                Name = "New",
                DirectorId = 6,
                Genre = Genre.Romance,
                ActorIds = new int[] { 3, 4 }
            };
            //Act
            var result = controller.Post(movie) as NotFoundObjectResult;
            //Assert
            Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode.Value);
        }
    }
}
