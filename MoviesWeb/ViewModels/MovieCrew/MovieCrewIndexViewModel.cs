using MoviesWeb.ViewModels.Movie;
using System.Collections.Generic;

namespace MoviesWeb.ViewModels.MovieCrew
{
    public class MovieCrewIndexViewModel
    {
        public MovieViewModel Movie { get; set; }

        public IEnumerable<MovieCrewViewModel> MovieCrew { get; set; }
    }
}
