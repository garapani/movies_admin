using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.MovieDirector
{
    public class MovieDirectorCreateViewModel
    {
        public int MovieId { get; set; }
        [DisplayName("Movie title")]
        public string MovieTitle { get; set; }
        [DisplayName("Movie Image")]
        public string MovieImageUrl { get; set; }
        [Required]
        public int DirectorId { get; set; }
        [DisplayName("Director name")]
        public string DirectorName { get; set; }
        [DisplayName("Director Image")]
        public string DirectorImageUrl { get; set; }
    }
}
