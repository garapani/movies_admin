using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Specifications.MovieSpecifications;
using Domain.Entity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.MovieDirectorFeature.Commands
{
    public sealed class DeleteMovieDirectorCommandHandler : IRequestHandler<DeleteMovieDirectorCommand, bool>
    {
        private readonly IAsyncRepository<Movie> _movieRepository;

        public DeleteMovieDirectorCommandHandler(IAsyncRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> Handle(DeleteMovieDirectorCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.FirstOrDefaultAsync(new GetMovieWithItemsSpecification(request.MovieId));
            var selectedMovieDirector = movie.MovieDirectors.FirstOrDefault(o => o.MovieId == request.MovieId && o.DirectorId == request.DirectorId);
            if (selectedMovieDirector != null)
            {
                movie.MovieDirectors.Remove(selectedMovieDirector);
                movie = await _movieRepository.UpdateAsync(movie);
            }
            return !movie.MovieDirectors.Any(ma => ma.MovieId == request.MovieId && ma.DirectorId == request.DirectorId);
        }
    }
}
