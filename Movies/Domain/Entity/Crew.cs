using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Crew : BaseEntity
    {
        public Crew()
        {
            Movies = new HashSet<MovieCrew>();
        }

        public string Name { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        public string Description { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<MovieCrew> Movies { get; set; } 
    }
}
