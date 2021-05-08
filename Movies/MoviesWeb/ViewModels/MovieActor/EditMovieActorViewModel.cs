using MoviesWeb.ViewModels.Actor;
using MoviesWeb.ViewModels.Movie;

namespace MoviesWeb.ViewModels.MovieActor
{
    public class EditMovieActorViewModel
    {
        public int MovieId { get; set; }
        public virtual MovieViewModel Movie { get; set; }

        public int ActorId { get; set; }
        public virtual ActorViewModel Actor { get; set; }

        [System.ComponentModel.DisplayName("Character name")]
        public string CharacterName { get; set; }
        [System.ComponentModel.DisplayName("Cast order")]
        public int CastOrder { get; set; }
    }
}
