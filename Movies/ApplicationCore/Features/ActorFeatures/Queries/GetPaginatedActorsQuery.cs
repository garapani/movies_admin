using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Specifications.ActorSpecifications;
using Domain.Entity;
using MediatR;
using ReflectionIT.Mvc.Paging;

namespace ApplicationCore.Features.ActorFeatures.Queries
{
    public class GetPaginatedActorsQuery : IRequest<PagingList<Actor>>
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

    public class GetPaginatedActorsQueryHandle : IRequestHandler<GetPaginatedActorsQuery, PagingList<Actor>>
    {
        private readonly IAsyncRepository<Actor> _repositoryAsync;

        public GetPaginatedActorsQueryHandle(IAsyncRepository<Actor> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PagingList<Actor>> Handle(GetPaginatedActorsQuery request, CancellationToken cancellationToken)
        {
            var paginatedActors = _repositoryAsync.ListAsync(new GetPaginatedActorsWithItemsSpecfication(request.SearchString, request.PageIndex, request.PageSize));
            var totalItems = await _repositoryAsync.CountAsync(new GetActorsSpecification(request.SearchString));
            return await PagingList.CreateAsync<Actor>(paginatedActors.OrderBy(p => p.ActorId),request.PageSize, request.PageIndex);
        }
    }
}
