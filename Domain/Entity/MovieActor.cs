using Domain.Common;
namespace Domain.Entity
{
    public class MovieActor : AuditableEntity
    {
        public MovieActor()
        {
        }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        public string CharacterName { get; set; }
        public int CastOrder { get; set; }
    }
}
