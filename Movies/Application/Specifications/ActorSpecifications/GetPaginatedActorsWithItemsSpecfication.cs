using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.ActorSpecifications
{
    public sealed class GetPaginatedActorsWithItemsSpecfication : Specification<Actor>
    {
        public GetPaginatedActorsWithItemsSpecfication(string searchString, int pageIndex, int pageSize)
        {
            if (!string.IsNullOrEmpty(searchString))
                Query.Where(a => a.Name.ToLower().Contains(searchString.ToLower()));
            Query.Skip((pageIndex - 1) * pageSize);
            Query.Take(pageSize);
            Query.Include(a => a.Image);
            Query.Include(a => a.Movies);
        }
    }
}
