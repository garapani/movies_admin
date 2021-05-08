using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieActorFeature.Commands
{
    public sealed class UpdateMovieActorCommand : IRequest<Movie>
    {
        public MovieActor MovieActor { get; private set; }

        public UpdateMovieActorCommand(MovieActor movieActor)
        {
            MovieActor = movieActor;
        }
    }
}
