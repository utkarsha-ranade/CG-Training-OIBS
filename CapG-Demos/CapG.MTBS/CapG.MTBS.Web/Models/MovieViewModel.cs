using CapG.MTBS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CapG.MTBS.Web.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int DirectorId { get; set; }
        public SelectList Director { get; set; }
        public ActorViewModel[] Actors{ get; set; }
    }
}
