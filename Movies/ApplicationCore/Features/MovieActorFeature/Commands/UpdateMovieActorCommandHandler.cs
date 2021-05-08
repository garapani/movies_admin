using ApplicationCore.Common.Interfaces.Repositories;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using ApplicationCore.Specifications.MovieSpecifications;

namespace ApplicationCore.Features.MovieActorFeature.Commands
{
    public sealed class UpdateMovieActorCommandHandler : IRequestHandler<UpdateMovieActorCommand, Movie>
    {
        private readonly IAsyncRepository<Movie> _movieRepository;

        public UpdateMovieActorCommandHandler(IAsyncRepository<Movie> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Movie> Handle(UpdateMovieActorCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.FirstOrDefaultAsync(new GetMovieWithItemsSpecification(request.MovieActor.MovieId));
            var movieActor = movie.MovieActors.FirstOrDefault(ma => ma.ActorId == request.MovieActor.ActorId && ma.MovieId == request.MovieActor.MovieId);
            movieActor.CastOrder = request.MovieActor.CastOrder;
            movieActor.CharacterName = request.MovieActor.CharacterName;
            return await _movieRepository.UpdateAsync(movie);
        }
    }
}
