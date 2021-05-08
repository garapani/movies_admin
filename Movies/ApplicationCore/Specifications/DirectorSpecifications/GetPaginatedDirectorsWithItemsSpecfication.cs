using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.DirectorSpecifications
{

    public sealed class GetPaginatedDirectorsWithItemsSpecfication : Specification<Director>
    {
        public GetPaginatedDirectorsWithItemsSpecfication(string searchString, int pageIndex, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
                Query.Where(d => d.Name.ToLower().Contains(searchString.ToLower()));
            Query.Include(d => d.Image);
            Query.Include(d => d.MovieDirectors);
            if (pageIndex > 0)
                Query.Skip((pageIndex - 1) * pageSize);
            Query.Take(pageSize);
        }
    }
}
