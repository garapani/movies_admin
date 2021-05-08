using MoviesWeb.ViewModels.Director;
using MoviesWeb.ViewModels.Movie;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.MovieDirector
{
    public class MovieDirectorViewModel
    {
        public int MovieId { get; set; }
        public virtual MovieViewModel Movie { get; set; }

        public int DirectorId { get; set; }
        public virtual DirectorViewModel Director { get; set; }

        [Display(Name = "Created Time")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }


        [Display(Name = "Last Modified Time")]
        public DateTime LastModifiedAt { get; set; }

        [Display(Name = "Last Modified By")]
        public string LastModifiedBy { get; set; }
    }

}
