using ApplicationCore.Common.Interfaces.Repositories;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.MovieDirectorFeature.Commands
{
    public sealed class CreateMovieDirectorCommandHandler : IRequestHandler<CreateMovieDirectorCommand, Movie>
    {
        private readonly IAsyncRepository<Movie> _movieRepository;

        public CreateMovieDirectorCommandHandler(IAsyncRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> Handle(CreateMovieDirectorCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.MovieDirector.MovieId);
            movie.MovieDirectors.Add(request.MovieDirector);
            return await _movieRepository.UpdateAsync(movie);
        }
    }
}
