using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Classwork.Models
{
    public class Layout
    {
        public int Id { get; set; }
      
        public string Logo { get; set; }
        [Column("Intagram")]
        public string InstagramUrl { get; set; }
        [Column("Facebook")]
        public string FacebookUrl { get; set; }
        [NotMapped]
        [Required]
        public IFormFile LogoFile { get; set; }
    }
}
