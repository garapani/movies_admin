using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.CastSpecifications
{
    public sealed class GetCastWithItemsSpecification : Specification<MovieCast>
    {
        public GetCastWithItemsSpecification(int movieId, int actorId)
        {
            Query.Where(c => c.ActorId == actorId && c.MovieId == movieId);
            Query.Include(m => m.Movie).ThenInclude(m => m.Image);
            Query.Include(m => m.Actor).ThenInclude(m => m.Image);
        }
    }
}
