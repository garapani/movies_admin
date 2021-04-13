using Ardalis.Specification;
using Domain.Entity;

namespace ApplicationCore.Specifications.MovieSpecifications
{
    public sealed class GetMovieWithItemsSpecification : Specification<Movie>
    {
        public GetMovieWithItemsSpecification(int id)
        {
            Query.Where(m => m.MovieId == id);
            Query.Include(m => m.Image);
            Query.Include(m => m.Video);
            Query.Include(m => m.MovieActors).ThenInclude(mc => mc.Actor);
            Query.Include(m => m.MovieCrew).ThenInclude(mc => mc.Crew);
        }
    }
}
