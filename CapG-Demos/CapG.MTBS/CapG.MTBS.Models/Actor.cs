using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace CapG.MTBS.Models
{
    public class Actor
    {
        public Actor()
        {
            MovieActors = new HashSet<MovieActor>();
        }
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        //[JsonIgnore]
        public ICollection<MovieActor> MovieActors { get; set; }  
    }
}
