using Domain.Entity;

namespace Domain.Dto
{
    public class VideoDto
    {
        public int VideoId { get; set; }

        public string VideoUrl { get; set; }

        public static VideoDto FromModel(Video model)
        {
            if (model != null)
            {
                return new VideoDto()
                {
                    VideoId = model.Id,
                    VideoUrl = model.VideoUrl,
                };
            }
            else
            {
                return null;
            }
        }

        public Video ToModel()
        {
            return new Video()
            {
                //Id = VideoId,
                VideoUrl = VideoUrl,
            };
        }
    }
}