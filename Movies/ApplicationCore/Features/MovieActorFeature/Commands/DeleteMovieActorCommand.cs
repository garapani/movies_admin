using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieActorFeature.Commands
{
    public sealed class DeleteMovieActorCommand: IRequest<bool>
    {
        public int MovieId { get; private set; }
        public int ActorId { get; private set; }

        public DeleteMovieActorCommand(int movieId, int actorId)
        {
            MovieId = movieId;
            ActorId = actorId;
        }

        public DeleteMovieActorCommand(int movieId)
        {
            MovieId = movieId;
        }
    }
}
