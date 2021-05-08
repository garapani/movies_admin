using MoviesWeb.ViewModels.Director;
using MoviesWeb.ViewModels.Movie;

namespace MoviesWeb.ViewModels.MovieDirector
{
    public class EditMovieDirectorViewModel
    {
        public int MovieId { get; set; }
        public virtual MovieViewModel Movie { get; set; }

        public int DirectorId { get; set; }
        public virtual DirectorViewModel Director { get; set; }
    }
}
