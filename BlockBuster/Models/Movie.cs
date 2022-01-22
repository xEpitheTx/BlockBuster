using System.ComponentModel.DataAnnotations;

namespace BlockBuster.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        public int GenreID { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; 
        }
        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int Stock { get; set; }
    }
}
