using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.CastSpecifications
{
    public sealed class GetCastWithItemsUsingMovieIdSpecification : Specification<MovieCast>
    {
        public GetCastWithItemsUsingMovieIdSpecification(int movieId)
        {
            Query.Where(c => c.MovieId == movieId);
            Query.Include(c => c.Movie).ThenInclude(m => m.Image);
            Query.Include(c => c.Actor).ThenInclude(m => m.Image);
        }
    }
}
