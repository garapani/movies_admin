using MoviesWeb.ViewModels.Movie;
using System.Collections.Generic;

namespace MoviesWeb.ViewModels.MovieCast
{
    public class MovieCastIndexViewModel
    {
        public MovieViewModel Movie { get; set; }

        public IEnumerable<MovieCastViewModel> Cast { get; set; }
    }
}
