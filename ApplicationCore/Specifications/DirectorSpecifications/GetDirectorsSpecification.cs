using Ardalis.Specification;
using Domain.Entity;
using System.Linq;

namespace ApplicationCore.Specifications.DirectorSpecifications
{
    public sealed class GetDirectorsSpecification : Specification<Director>
    {
        public GetDirectorsSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                Query.Where(a => a.Name.ToLower().Contains(searchString.ToLower()));
        }
    }
}
