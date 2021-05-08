using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Common.Interfaces.Repositories;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieFeatures.Commands
{
    public sealed class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie>
    {
        private readonly IAsyncRepository<Movie> _movieRepository;

        public CreateMovieCommandHandler(IAsyncRepository<Movie> MovieRepository)
        {
            _movieRepository = MovieRepository;
        }

        public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            return await _movieRepository.AddAsync(request.Movie);
        }
    }
}
