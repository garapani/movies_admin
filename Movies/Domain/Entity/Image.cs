using Domain.Common;
namespace Domain.Entity
{
    public class Image : Common.BaseEntity, IAggregateRoot
    {
        public Image()
        {
        }
        public string ImageUrl { get; set; }
    }
}
