using Domain.Entity;
using System;

namespace Domain.Dto
{
    public class ActorDto
    {
        public ActorDto()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int ImageId { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public static ActorDto FromModel(Actor model)
        {
            return new ActorDto()
            {
                Id = model.Id,
                Name = model.Name,
                ImageId = model.Image != null ? model.Image.Id : 0,
                ImageUrl = model.Image?.ImageUrl,
                Description = model.Description,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt
            };
        }

        public Actor ToModel()
        {
            return new Actor()
            {
                //Id = Id,
                Name = Name,
                //ImageId = ImageId,
                Image = new Image
                {
                    ImageUrl = ImageUrl
                }
            };
        }
    }
}
