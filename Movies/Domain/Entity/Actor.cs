using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Actor : BaseEntity, IAggregateRoot
    {
        public Actor()
        {
            Movies = new HashSet<MovieCast>();
        }
        
        public string Name { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MovieCast> Movies { get; set; }
    }
}
