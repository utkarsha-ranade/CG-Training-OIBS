using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapG.MTBS.Models
{
    public class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Director Name")]
        public string Name { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
