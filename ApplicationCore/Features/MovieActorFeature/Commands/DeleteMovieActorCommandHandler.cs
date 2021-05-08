using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Specifications.MovieSpecifications;
using Domain.Entity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.MovieActorFeature.Commands
{
    public sealed class DeleteMovieActorCommandHandler : IRequestHandler<DeleteMovieActorCommand, bool>
    {
        private readonly IAsyncRepository<Movie> _movieRepository;

        public DeleteMovieActorCommandHandler(IAsyncRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<bool> Handle(DeleteMovieActorCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.FirstOrDefaultAsync(new GetMovieWithItemsSpecification(request.MovieId));
            var selectedMovieActor = movie.MovieActors.FirstOrDefault(o => o.MovieId == request.MovieId && o.ActorId == request.ActorId);
            if (selectedMovieActor != null)
            {
                movie.MovieActors.Remove(selectedMovieActor);
                movie = await _movieRepository.UpdateAsync(movie);
            }
            return !movie.MovieActors.Any(ma => ma.MovieId == request.MovieId && ma.ActorId == request.ActorId);
        }
    }
}
