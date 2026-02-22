using CapG.MTBS.Models;
using CapG.MTBS.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapG.MTBS.Repositories
{
    public interface IMovieRepository: IRepository<MovieDto>
    {
        IEnumerable<Actor> GetCast(int id);
    }
}
