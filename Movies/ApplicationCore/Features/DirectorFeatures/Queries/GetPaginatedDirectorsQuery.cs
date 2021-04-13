using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using Domain.Entity;
using MediatR;
using ReflectionIT.Mvc.Paging;

namespace ApplicationCore.Features.DirectorFeatures.Queries
{
    public class GetPaginatedDirectorsQuery : IRequest<PagingList<Director>>
    {
        public GetPaginatedDirectorsQuery(string searchString, int pageIndex, int pageSize)
        {
            SearchString = searchString;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public string SearchString { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class GetPaginatedDirectorsQueryHandle : IRequestHandler<GetPaginatedDirectorsQuery, PagingList<Director>>
    {
        private readonly IAsyncRepository<Director> _repositoryAsync;

        public GetPaginatedDirectorsQueryHandle(IAsyncRepository<Director> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PagingList<Director>> Handle(GetPaginatedDirectorsQuery request, CancellationToken cancellationToken)
        {
            return null;
            //return await _repositoryAsync.PaginatedListAsync(new GetPaginatedDirectorsWithItemsSpecfication(request.SearchString, request.PageIndex, request.PageSize));
        }
    }
}
