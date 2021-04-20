using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Specifications.ActorSpecifications;
using Domain.Entity;
using MediatR;
using ApplicationCore.Paging;

namespace ApplicationCore.Features.ActorFeatures.Queries
{
    public class GetPaginatedActorsQuery : IRequest<PaginatedList<Actor>>
    {
        public GetPaginatedActorsQuery(string searchString, int pageIndex, int pageSize)
        {
            SearchString = searchString;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public string SearchString { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class GetPaginatedActorsQueryHandle : IRequestHandler<GetPaginatedActorsQuery, PaginatedList<Actor>>
    {
        private readonly IAsyncRepository<Actor> _repositoryAsync;

        public GetPaginatedActorsQueryHandle(IAsyncRepository<Actor> repositoryAsync)
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
