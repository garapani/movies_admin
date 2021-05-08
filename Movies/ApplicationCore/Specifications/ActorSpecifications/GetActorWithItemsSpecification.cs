using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.ActorSpecifications
{
    public sealed class GetActorWithItemsSpecification : Specification<Actor>
    {
        public GetActorWithItemsSpecification(int id)
        {
            Query.Where(a => a.ActorId == id);
            Query.Include(a => a.Image);
            Query.Include(a => a.MovieActors).ThenInclude(o => o.Movie);
        }
    }
}
