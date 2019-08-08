using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPNETMVC.Models
{
    public class Movie
    {
        public int? Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [NumberInStockFrom1To20]
        public int NumberInStock { get; set; }

        public Genre Genre { get; set; }
    }
}