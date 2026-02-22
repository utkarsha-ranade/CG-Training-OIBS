using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CapG.MTBS.Models
{
    public class CustomUser : IdentityUser
    {
        public Gender Gender { get; set; }
        [Required]
        [MinLength(5)]
        public string Address { get; set; }
    }
}
