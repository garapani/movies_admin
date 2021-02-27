using Domain.Common;

namespace Domain.Entity
{
    public class MovieDirector : BaseEntity, IAggregateRoot
    {
        public MovieDirector()
        {
        }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Actor { get; set; }
        public string CharacterName { get; set; }
        public int CastOrder { get; set; }
    }
}
