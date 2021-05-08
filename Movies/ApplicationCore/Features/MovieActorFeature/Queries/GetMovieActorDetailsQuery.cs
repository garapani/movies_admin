using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieActorFeature.Queries
{
    public class GetMovieActorDetailsQuery : IRequest<MovieActor>
    {
        public GetMovieActorDetailsQuery(int movieId, int actorId)
        {
            this.MovieId = movieId;
            this.ActorId = actorId;
        }

        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}
