using ApplicationCore.Common.Interfaces.Repositories;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.MovieActorFeature.Commands
{
    public sealed class CreateMovieActorCommandHandler : IRequestHandler<CreateMovieActorCommand, Movie>
    {
        private readonly IAsyncRepository<Movie> _movieRepository;

        public CreateMovieActorCommandHandler(IAsyncRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> Handle(CreateMovieActorCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetByIdAsync(request.MovieActor.MovieId);
            movie.MovieActors.Add(request.MovieActor);
            return await _movieRepository.UpdateAsync(movie);
        }
    }
}
