using Domain.Common;

namespace Domain.Entity
{
    public class MovieGenre : IAggregateRoot
    {
        public MovieGenre()
        {

        }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
