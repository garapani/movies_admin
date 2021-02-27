using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.DirectorSpecifications
{
    public sealed class GetDirectorWithItemsSpecification : Specification<Director>
    {
        public GetDirectorWithItemsSpecification(int id)
        {
            Query.Where(d => d.Id == id);
            Query.Include(d => d.Image);
            Query.Include(d => d.Movies);
        }
    }
}
