using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.MovieSpecifications
{
    public sealed class GetMoviesSpecification : Specification<Movie>
    {
        public GetMoviesSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
                Query.Where(m => m.Title.ToLower().Contains(searchString.ToLower()));
        }
    }
}
