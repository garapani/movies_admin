using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.MovieActor
{
    public class MovieActorCreateViewModel
    {
        public int MovieId { get; set; }
        [System.ComponentModel.DisplayName("Movie title")]
        public string MovieTitle { get; set; }
        [System.ComponentModel.DisplayName("Movie Image")]
        public string MovieImageUrl { get; set; }
        [Required]
        public int ActorId { get; set; }
        [System.ComponentModel.DisplayName("Actor name")]
        public string ActorName { get; set; }
        [System.ComponentModel.DisplayName("Actor Image")]
        public string ActorImageUrl { get; set; }
        [System.ComponentModel.DisplayName("Character name")]
        public string CharacterName { get; set; }
        [System.ComponentModel.DisplayName("Cast order")]
        public string CastOrder { get; set; }
    }
}
