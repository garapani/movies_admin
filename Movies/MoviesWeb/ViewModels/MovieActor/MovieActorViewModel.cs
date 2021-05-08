using MoviesWeb.ViewModels.Actor;
using MoviesWeb.ViewModels.Movie;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesWeb.ViewModels.MovieActor
{
    public class MovieActorViewModel
    {
        public int MovieId { get; set; }
        public virtual MovieViewModel Movie { get; set; }

        public int ActorId { get; set; }
        public virtual ActorViewModel Actor { get; set; }

        [System.ComponentModel.DisplayName("Character name")]
        public string CharacterName { get; set; }
        [System.ComponentModel.DisplayName("Cast order")]
        public int CastOrder { get; set; }


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
