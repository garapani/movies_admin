using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Movie : BaseEntity, IAggregateRoot
    {
        public Movie()
        {
            this.Cast = new HashSet<MovieCast>();
            this.Crew = new HashSet<MovieCrew>();
            this.Keywords = new HashSet<Keyword>();
            this.Genres = new HashSet<MovieGenre>();
        }

        public string Title { get; set; }

        public string LocalTitle { get; set; }

        public virtual ICollection<MovieCast> Cast { get; set; }

        public virtual ICollection<MovieCrew> Crew { get; set; }

        public virtual Image Image { get; set; }

        public virtual Video Video { get; set; }

        public virtual ICollection<Keyword> Keywords { get; set; }

        public virtual Language Language { get; set; }

        public string Overview { get; set; }

        public int? Popularity { get; set; }

        public virtual ICollection<MovieGenre> Genres { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public TimeSpan? RunTime { get; set; }

        public string Tagline { get; set; }

        public int? ViewCount { get; set; }
    }
}
