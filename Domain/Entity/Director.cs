using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Director : AuditableEntity, IAggregateRoot
    {
        public Director()
        {
            MovieDirectors = new HashSet<MovieDirector>();
        }

        public virtual int DirectorId { get; set; }
        public string Name { get; set; }
        public virtual Image Image { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MovieDirector> MovieDirectors { get; set; }
    }
}
