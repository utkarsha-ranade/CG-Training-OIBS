using CapG.MTBS.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CapG.MTBS.Web.Models
{
    public class MovieCastViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public string DirectorName { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}
