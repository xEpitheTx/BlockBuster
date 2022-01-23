using BlockBuster.Models;
using System.ComponentModel.DataAnnotations;

namespace BlockBuster.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreID { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate
        {
            get; set;
        }

        [Range(1, 20)]
        [Required]
        [Display(Name = "Number in Stock")]
        public int? Stock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            GenreID = movie.GenreID;
        }
    }
}
