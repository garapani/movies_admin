using Domain.Entity;
using System;

namespace Domain.Dto
{
    public class MovieDto
    {
        public MovieDto()
        {
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string LocalTitle { get; set; }
        public ImageDto Image { get; set; }
        public VideoDto Video { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public static MovieDto FromModel(Movie model)
        {
            MovieDto movieDto = new MovieDto
            {
                MovieId = model.Id,
                Title = model.Title,
                LocalTitle = model.LocalTitle,
                Image = ImageDto.FromModel(model.Image),
                Video = VideoDto.FromModel(model.Video),
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt
            };
            return movieDto;
        }

        public Movie ToModel()
        {
            return new Movie()
            {
                //Id = this.MovieId,
                Title = this.Title,
                LocalTitle = this.LocalTitle,
                Image = Image?.ToModel(),
                Video = Video?.ToModel()
            };
        }
    }
}
