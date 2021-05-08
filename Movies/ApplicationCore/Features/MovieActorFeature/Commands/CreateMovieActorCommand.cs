using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieActorFeature.Commands
{
    public sealed class CreateMovieActorCommand : IRequest<Movie>
    {
        public MovieActor MovieActor { get; private set; }

        public CreateMovieActorCommand(MovieActor movieActor)
        {
            MovieActor = movieActor;
        }
    }
}
