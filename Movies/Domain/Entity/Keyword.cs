using Domain.Common;
namespace Domain.Entity
{
    public class Keyword: BaseEntity, IAggregateRoot
    {
        public Keyword()
        {
        }
        public string Name { get; set; }
    }
}
