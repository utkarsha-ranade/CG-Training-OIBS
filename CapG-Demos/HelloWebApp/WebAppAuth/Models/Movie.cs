using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppAuth.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        [MinLength(3)]
        public string Director { get; set; }
        public Genre Genre { get; set; }
    }
}
