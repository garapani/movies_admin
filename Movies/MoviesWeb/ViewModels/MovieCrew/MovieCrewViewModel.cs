using MoviesWeb.ViewModels.Crew;
using MoviesWeb.ViewModels.Movie;

namespace MoviesWeb.ViewModels.MovieCrew
{
    public class MovieCrewViewModel
    {
        public int MovieId { get; set; }
        public virtual MovieViewModel Movie { get; set; }

        public int CrewId { get; set; }
        public virtual CrewViewModel Crew { get; set; }

        public int Order { get; set; }
    }
}
