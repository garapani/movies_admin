using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Specifications.MovieSpecifications;
using Domain.Entity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.MovieActorFeature.Queries
{
    public class GetMovieActorDetailsQueryHandler : IRequestHandler<GetMovieActorDetailsQuery, MovieActor>
    {
        private readonly IAsyncRepository<Movie> _asyncRepository;
        public GetMovieActorDetailsQueryHandler(IAsyncRepository<Movie> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<MovieActor> Handle(GetMovieActorDetailsQuery request, CancellationToken cancellationToken)
        {
            var movieDetails = await _asyncRepository.FirstOrDefaultAsync(new GetMovieWithItemsSpecification(request.MovieId));
            return movieDetails.MovieActors.FirstOrDefault(ma => ma.ActorId == request.ActorId);
        }
    }
}
