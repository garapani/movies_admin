using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.DirectorSpecifications
{
    public sealed class GetDirectorWithItemsSpecification : Specification<Director>
    {
        public GetDirectorWithItemsSpecification(int id)
        {
            Query.Where(d => d.DirectorId == id);
            Query.Include(d => d.Image);
            Query.Include(d => d.MovieDirectors);
        }
    }
}
