using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieDirectorFeature.Commands
{
    public sealed class CreateMovieDirectorCommand : IRequest<Movie>
    {
        public MovieDirector MovieDirector { get; private set; }

        public CreateMovieDirectorCommand(MovieDirector movieDirector)
        {
            MovieDirector = movieDirector;
        }
    }
}
