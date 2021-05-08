using ApplicationCore.Common.Models;
using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Specifications.ActorSpecifications;
using Domain.Entity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.ActorFeatures.Queries
{
    public class GetPaginatedActorsQueryHandler : IRequestHandler<GetPaginatedActorsQuery, PaginatedList<Actor>>
    {
        private readonly IAsyncRepository<Actor> _repositoryAsync;

        public GetPaginatedActorsQueryHandler(IAsyncRepository<Actor> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PaginatedList<Actor>> Handle(GetPaginatedActorsQuery request, CancellationToken cancellationToken)
        {
            var paginatedActors = await _repositoryAsync.ListAsync(new GetPaginatedActorsWithItemsSpecfication(request.SearchString, request.PageIndex, request.PageSize));
            var totalItems = await _repositoryAsync.CountAsync(new GetActorsSpecification(request.SearchString));
            return new PaginatedList<Actor>(paginatedActors.ToList(), totalItems, request.PageIndex, request.PageSize);
        }
    }
}
