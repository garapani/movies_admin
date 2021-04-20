using MoviesWeb.ViewModels.Movie;
using System.Collections.Generic;

namespace MoviesWeb.ViewModels.MovieActor
{
    public class MovieActorIndexViewModel
    {
        public MovieViewModel Movie { get; set; }

        public IEnumerable<MovieActorViewModel> MovieActors { get; set; }
    }
}
