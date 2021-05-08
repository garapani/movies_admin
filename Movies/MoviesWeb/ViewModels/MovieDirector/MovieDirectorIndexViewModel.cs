using MoviesWeb.ViewModels.Movie;
using System.Collections.Generic;

namespace MoviesWeb.ViewModels.MovieDirector
{
    public class MovieDirectorIndexViewModel
    {
        public MovieViewModel Movie { get; set; }

        public IEnumerable<MovieDirectorViewModel> MovieDirectors { get; set; }
    }
}