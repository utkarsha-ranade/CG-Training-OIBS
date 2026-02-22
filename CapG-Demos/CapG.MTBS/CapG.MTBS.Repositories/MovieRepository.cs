using CapG.MTBS.Exceptions;
using CapG.MTBS.Models;
using CapG.MTBS.Models.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapG.MTBS.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MTBSContext context;
        public MovieRepository(MTBSContext context)
        {
            this.context = context;
        }

        public bool Add(MovieDto entity)
        {
            try
            {
                //duplicate
                var movie = context.Movies.FirstOrDefault(m =>
                                m.Name == entity.Name
                                && m.DirectorId == entity.DirectorId);
                if (movie != null)
                    throw new MtbsException("Movie already exists");

                //actor exists?
                foreach (var actorId in entity.ActorIds)
                {
                    var actor = context.Actors.Find(actorId);
                    if (actor == null)
                    {
                        throw new MtbsException($"Actor does not exist for actor id {actorId}");
                    }                   
                }

                //director exists?
                var director = context.Directors.Find(entity.DirectorId);
                if (director == null)
                {
                    throw new MtbsException("Director does not exist");
                }

                //add movie
                Movie newMovie = new Movie 
                {
                    Name = entity.Name,
                    Genre = entity.Genre,
                    DirectorId = entity.DirectorId
                }; 
                List<MovieActor> movieActors = new List<MovieActor>();
                foreach (var actorId in entity.ActorIds)
                {
                    movieActors.Add(new MovieActor
                    {
                        MovieId = newMovie.Id,
                        ActorId = actorId
                    });
                }
                newMovie.MovieActors = movieActors;
                context.Movies.Add(newMovie);
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }

        public bool Delete(object key)
        {
            try
            {
                var customer = context.Movies.Find(key);
                customer.IsDeleted = true;
                context.Movies.Update(customer);
                int recordsAffected = context.SaveChanges();
                if (recordsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }

        public MovieDto Get(object key)
        {
            //try
            //{
                //var movie = context.Movies.Include(m => m.MovieActors).FirstOrDefault(m => m.Id == Convert.ToInt32(key));
                //if (movie == null)
                //{
                //    throw new MtbsException("Movie not found");
                //}
                var movie = context.Movies.Include(m => m.Director).FirstOrDefault(m => m.Id == Convert.ToInt32(key));
                var movieDto = new MovieDto
                {
                    Id = movie.Id,
                    Name = movie.Name,
                    Genre = movie.Genre,
                    DirectorId = movie.DirectorId,
                    Director = movie.Director
                };
                return movieDto;
            //}
            //catch (SqlException ex)
            //{
            //    throw new MtbsException(ex.Message);
            //}
        }

        public IEnumerable<MovieDto> Get()
        {
            try
            {
                //var list = context.Movies.ToList();
                //transform from Movie to Dto
                var dtos = context.Movies.Select(m => new MovieDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Genre = m.Genre,
                    DirectorId= m.DirectorId,
                    Director = m.Director,
                    IsDeleted = m.IsDeleted
                });
                return dtos;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }

        public IEnumerable<Actor> GetCast(int id)
        {
            try
            {
                var list = context.MovieActors.Where(ma =>
                ma.MovieId == id).Select(ma => ma.Actor).ToList();
                return list;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }

        public bool Update(MovieDto entity)
        {
            try
            {
                //dto => M
                Movie movie = new Movie
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    DirectorId = entity.DirectorId,
                    Genre = entity.Genre,
                };
                List<MovieActor> movieActors = new List<MovieActor>();
                foreach (var actorId in entity.ActorIds)
                {
                    movieActors.Add(new MovieActor
                    {
                        MovieId = entity.Id,
                        ActorId = actorId
                    });
                }
                //movie.MovieActors.Clear();
                context.MovieActors.RemoveRange(context.MovieActors.Where(ma => 
                                    ma.MovieId == entity.Id));
                context.SaveChanges();
                
                movie.MovieActors = movieActors;
                context.Movies.Update(movie);
                //context.MovieActors.AddRange(movieActors);
                int recordsAffected = context.SaveChanges();
                if(recordsAffected > 0)
                {
                    return true;
                }
                return false;
            }
            catch (SqlException ex)
            {
                throw new MtbsException(ex.Message);
            }
        }
    }
}
