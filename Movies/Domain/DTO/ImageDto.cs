using Domain.Entity;
using System;

namespace Domain.Dto
{
    public class ImageDto
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public static ImageDto FromModel(Image model)
        {
            if (model != null)
            {
                return new ImageDto()
                {
                    Id = model.Id,
                    ImageUrl = model.ImageUrl,
                    CreatedAt = model.CreatedAt,
                    UpdatedAt = model.UpdatedAt
                };
            }
            return null;
        }

        public Image ToModel()
        {
            return new Image()
            {
                //Id = Id,
                ImageUrl = ImageUrl
            };
        }
    }
}