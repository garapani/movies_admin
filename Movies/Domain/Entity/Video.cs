using Domain.Common;
namespace Domain.Entity
{
    public class Video: BaseEntity, IAggregateRoot
    {
        public Video()
        {
        }

        public string VideoUrl { get; set; }
    }
}
