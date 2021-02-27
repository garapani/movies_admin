using System.Collections.Generic;
using System.Linq;
using Domain.Entity;

namespace Domain.Dto
{
    public class ActorDetailDto
    {
        public ActorDetailDto()
        {
            Movies = new HashSet<MovieDto>();
        }
        public int ActorId { get; set; }

        public string Name { get; set; }

        public ImageDto Image { get; set; }
        public ICollection<MovieDto> Movies { get; set; }
        public string Description { get; set; }

        public static ActorDetailDto FromModel(Actor model)
        {
            var actorDetailDto = new ActorDetailDto
            {
                ActorId = model.Id,
                Name = model.Name,
                Image = ImageDto.FromModel(model.Image),
                Description = model.Description,
            };
            model.Movies.ToList().ForEach(m => actorDetailDto.Movies.Add(MovieDto.FromModel(m.Movie)));
            return actorDetailDto;
        }

        public Actor FromDto(ActorDetailDto actorDetailDto)
        {
            Image image = new Image();
            if (actorDetailDto.Image != null)
            {
                image.ImageUrl = actorDetailDto.Image.ImageUrl;
            }

            ICollection<MovieCast> movieCast = new HashSet<MovieCast>();
            if (actorDetailDto.Movies != null)
            {
                actorDetailDto.Movies.ToList().ForEach(m =>
                {
                    movieCast.Add(new MovieCast
                    {
                        MovieId = m.MovieId,
                        ActorId = this.ActorId
                    });
                });
            }

            var actor = new Actor
            {
                Name = actorDetailDto.Name,
                Description = actorDetailDto.Description,
                Movies = movieCast
            };
            return actor;
        }
    }
}
