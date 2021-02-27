using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.ActorSpecifications
{
    public sealed class GetActorsSpecification : Specification<Actor>
    {
        public GetActorsSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                Query.Where(a => a.Name.ToLower().Contains(searchString.ToLower()));
        }
    }
}
