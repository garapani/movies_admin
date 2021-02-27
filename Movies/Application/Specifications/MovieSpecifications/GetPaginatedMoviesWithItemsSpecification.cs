using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.MovieSpecifications
{
    public sealed class GetPaginatedMoviesWithItemsSpecification : Specification<Movie>
    {
        public GetPaginatedMoviesWithItemsSpecification(string searchString, int pageIndex, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Query.Where(m => m.Title.ToLower().Contains(searchString.ToLower()));
            }
            Query.Include(m => m.Image);
            Query.Include(m => m.Video);
            Query.Include(m => m.Cast).ThenInclude(mc => mc.Actor);
            Query.Include(m => m.Crew).ThenInclude(mc => mc.Crew);
            Query.Skip((pageIndex - 1) * pageSize);
            Query.Take(pageSize);
        }
    }
}
