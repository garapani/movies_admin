using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Movie : AuditableEntity, IAggregateRoot
    {
        public Movie()
        {
            this.MovieActors = new HashSet<MovieActor>();
            this.MovieCrew = new HashSet<MovieCrew>();
            this.MovieDirectors = new HashSet<MovieDirector>();
            this.Keywords = new HashSet<Keyword>();
            this.Genres = new HashSet<Genre>();
        }
        public virtual int MovieId { get; set; }

        public string Title { get; set; }

        public string LocalTitle { get; set; }

        public virtual ICollection<MovieActor> MovieActors { get; set; }
        public virtual ICollection<MovieCrew> MovieCrew { get; set; }
        public virtual ICollection<MovieDirector> MovieDirectors { get; set; }

        public Image Image { get; set; }

        public Video Video { get; set; }

        public virtual ICollection<Keyword> Keywords { get; set; }

        public virtual Language Language { get; set; }

        public string Overview { get; set; }

        public int? Popularity { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public TimeSpan? RunTime { get; set; }

        public string Tagline { get; set; }

        public int? ViewCount { get; set; }
    }
}
