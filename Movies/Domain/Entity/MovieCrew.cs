using Domain.Common;
namespace Domain.Entity
{
    public class MovieCrew : IAggregateRoot
    {
        public MovieCrew()
        {
        }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int CrewId { get; set; }
        public virtual Crew Crew { get; set; }
    }
}
