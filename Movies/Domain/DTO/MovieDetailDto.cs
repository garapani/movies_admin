using Domain.Entity;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Domain.Dto
{
    public class MovieDetailDto
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string LocalTitle { get; set; }

        public ICollection<MovieCastDto> Cast { get; set; }

        public ICollection<MovieCrewDto> Crew { get; set; }

        public ImageDto Image { get; set; }

        public VideoDto Video { get; set; }

        public ICollection<KeywordDto> Keywords { get; set; }

        public LanguageDto Language { get; set; }

        public string Overview { get; set; }

        public int? Popularity { get; set; }

        public ICollection<GenreDto> Genres { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public TimeSpan? RunTime { get; set; }

        public string Tagline { get; set; }

        public int? ViewCount { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public MovieDetailDto()
        {
            Cast = new HashSet<MovieCastDto>();
            Crew = new HashSet<MovieCrewDto>();
            Keywords = new HashSet<KeywordDto>();
            Genres = new HashSet<GenreDto>();
        }

        public static MovieDetailDto FromModel(Movie model)
        {
            var movieDetailsDto = new MovieDetailDto()
            {
                MovieId = model.Id,
                Title = model.Title,
                LocalTitle = model.LocalTitle,
                Language = LanguageDto.FromModel(model.Language),
                Overview = model.Overview,
                Popularity = model.Popularity,
                ReleaseDate = model.ReleaseDate,
                RunTime = model.RunTime,
                Tagline = model.Tagline,
                ViewCount = model.ViewCount,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                Image = ImageDto.FromModel(model.Image),
                Video = VideoDto.FromModel(model.Video),
            };

            model.Cast.ToList().ForEach(c => movieDetailsDto.Cast.Add(MovieCastDto.FromModel(c)));
            model.Crew.ToList().ForEach(c => movieDetailsDto.Crew.Add(MovieCrewDto.FromModel(c)));
            model.Keywords.ToList().ForEach(k => movieDetailsDto.Keywords.Add(KeywordDto.FromModel(k)));
            model.Genres.ToList().ForEach(g => movieDetailsDto.Genres.Add(GenreDto.FromModel(g.Genre)));
            return movieDetailsDto;
        }

        public Movie ToModel()
        {
            List<MovieCast> movieCast = new List<MovieCast>();
            List<MovieCrew> movieCrew = new List<MovieCrew>();
            List<Keyword> keywords = new List<Keyword>();
            List<MovieGenre> genres = new List<MovieGenre>();

            Cast.ToList().ForEach(c =>
                movieCast.Add(new MovieCast
                {
                    MovieId = this.MovieId,
                    ActorId = c.ActorId
                }));

            Crew.ToList().ForEach(c =>
                movieCrew.Add(new MovieCrew
                {
                    MovieId = this.MovieId,
                    CrewId = c.CrewId
                }));


            Keywords.ToList().ForEach(k =>
                keywords.Add(new Keyword
                {
                    //Id = k.KeywordId
                }));

            Genres.ToList().ForEach(g =>
                genres.Add(new MovieGenre
                {
                    GenreId = g.GenreId,
                    MovieId = this.MovieId
                }));

            var movie = new Movie()
            {
                //Id = MovieId,
                Title = Title,
                LocalTitle = LocalTitle,
                Cast = movieCast,
                Crew = movieCrew,
                Keywords = keywords,
                Language = Language.ToModel(),
                Overview = Overview,
                Popularity = Popularity,
                Image = Image?.ToModel(),
                Video = Video?.ToModel(),
                Genres = genres,
                ReleaseDate = ReleaseDate,
                RunTime = RunTime,
                Tagline = Tagline,
                ViewCount = ViewCount
            };
            return movie;
        }
    }
}