using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieDirectorFeature.Queries
{
    public class GetMovieDirectorDetailsQuery : IRequest<MovieDirector>
    {
        public GetMovieDirectorDetailsQuery(int movieId, int directorId)
        {
            this.MovieId = movieId;
            this.DirectorId = directorId;
        }

        public int MovieId { get; set; }
        public int DirectorId { get; set; }
    }
}
