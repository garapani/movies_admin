using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Actor : AuditableEntity, IAggregateRoot
    {
        public Actor()
        {
            MovieActors = new HashSet<MovieActor>();
        }

        public virtual int ActorId { get; set; }

        public virtual string Name { get; set; }
        public virtual Image Image { get; set; }
        public virtual string Description { get; set; }
        public virtual Gender Gender { get; set;}
        public virtual ICollection<MovieActor> MovieActors { get; set; }
    }
}
