using System.Collections.Generic;
using Domain.Common;
namespace Domain.Entity
{
    public class Video: ValueObject<Video>
    {
        private Video()
        {
        }

        public Video(string videoUrl)
        {
            VideoUrl = videoUrl;
        }

        public string VideoUrl { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return VideoUrl;
        }
    }
}
