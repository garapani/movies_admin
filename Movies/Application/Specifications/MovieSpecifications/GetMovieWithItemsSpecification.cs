using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.MovieSpecifications
{
    public sealed class GetMovieWithItemsSpecification : Specification<Movie>
    {
        public GetMovieWithItemsSpecification(int id)
        {
            Query.Where(m => m.Id == id);
            Query.Include(m => m.Image);
            Query.Include(m => m.Video);
            Query.Include(m => m.Cast).ThenInclude(mc => mc.Actor);
            Query.Include(m => m.Crew).ThenInclude(mc => mc.Crew);
        }
    }
}
