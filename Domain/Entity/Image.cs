using System.Collections.Generic;
using Domain.Common;
namespace Domain.Entity
{
    public class Image : ValueObject<Image>
    {
        public string ImageUrl { get; }

        private Image() { }
        public Image(string imageUrl)
        {
            ImageUrl = imageUrl;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ImageUrl;
        }
    }
}
