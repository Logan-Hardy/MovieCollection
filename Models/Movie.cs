using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Models
{
    public class Movie
    {
        [Required]
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string MovieTitle { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }


        //These attributes are not required 
        public bool? Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25, ErrorMessage = "That note is TOO long!")]
        public string Notes { get; set; }
    }
}
