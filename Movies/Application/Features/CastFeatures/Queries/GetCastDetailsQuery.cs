using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Specifications.CastSpecifications;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.CastFeatures.Queries
{
    public class GetCastDetailsQuery : IRequest<MovieCast>
    {
        public GetCastDetailsQuery(int movieId, int actorId)
        {
            MovieId = movieId;
            ActorId = actorId;
        }

        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }


    public class GetCastDetailsQueryHandle : IRequestHandler<GetCastDetailsQuery, MovieCast>
    {
        private readonly IAsyncRepository<MovieCast> _repositoryAsync;

        public GetCastDetailsQueryHandle(IAsyncRepository<MovieCast> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<MovieCast> Handle(GetCastDetailsQuery request, CancellationToken cancellationToken)
        {
            var listOfCast = await _repositoryAsync.ListAsync(new GetCastWithItemsSpecification(request.MovieId, request.ActorId));
            if (listOfCast != null)
                return listOfCast.FirstOrDefault();
            return null;
        }
    }
}
