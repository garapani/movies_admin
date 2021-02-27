using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.ActorSpecifications
{
    public sealed class GetActorWithItemsSpecification : Specification<Actor>
    {
        public GetActorWithItemsSpecification(int id)
        {
            Query.Where(a => a.Id == id);
            Query.Include(a => a.Image);
            Query.Include(a => a.Movies);
        }
    }
}
