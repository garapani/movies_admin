using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Crew : AuditableEntity, IAggregateRoot
    {
        public Crew()
        {
            MovieCrew = new HashSet<MovieCrew>();
        }

        public virtual int CrewId { get; set; }
        public string Name { get; set; }
        public Image Image { get; set; }
        public string Description { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<MovieCrew> MovieCrew { get; set; } 
    }
}
