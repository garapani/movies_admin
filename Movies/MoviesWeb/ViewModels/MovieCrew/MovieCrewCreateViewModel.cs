using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.MovieCrew
{
    public class MovieCrewCreateViewModel
    {
        public int MovieId { get; set; }
        [System.ComponentModel.DisplayName("Movie title")]
        public string MovieTitle { get; set; }
        [System.ComponentModel.DisplayName("Movie Image")]
        public string MovieImageUrl { get; set; }

        [Required]
        public int CrewId { get; set; }
        [System.ComponentModel.DisplayName("Crew name")]
        public string CrewName { get; set; }
        [System.ComponentModel.DisplayName("Crew Image")]
        public string CrewImageUrl { get; set; }

        public int Order { get; set; }
    }
}
