using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieFeatures.Commands
{
    public sealed class CreateMovieCommand : IRequest<Movie>
    {
        public Movie Movie { get; private set; }

        public CreateMovieCommand(Movie movie)
        {
            Movie = movie;
        }
    }
}
