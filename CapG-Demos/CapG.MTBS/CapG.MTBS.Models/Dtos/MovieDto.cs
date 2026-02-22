using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace CapG.MTBS.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        [JsonIgnore]
        public int[] ActorIds { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;
    }
}
