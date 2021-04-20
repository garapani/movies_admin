using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Paging;
using ApplicationCore.Specifications.MovieSpecifications;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieFeatures.Queries
{
    public class GetPaginatedMoviesQuery : IRequest<PaginatedList<Movie>>
    {
        public GetPaginatedMoviesQuery(string searchString, int pageIndex, int pageSize)
        {
            SearchString = searchString;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public string SearchString { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }

    public class GetPaginatedMoviesQueryHandle : IRequestHandler<GetPaginatedMoviesQuery, PaginatedList<Movie>>
    {
        private readonly IAsyncRepository<Movie> _repositoryAsync;

        public GetPaginatedMoviesQueryHandle(IAsyncRepository<Movie> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PaginatedList<Movie>> Handle(GetPaginatedMoviesQuery request, CancellationToken cancellationToken)
        {
            var paginatedMovies = await _repositoryAsync.ListAsync(new GetPaginatedMoviesWithItemsSpecification(request.SearchString, request.PageIndex, request.PageSize));
            var totalItems = await _repositoryAsync.CountAsync(new GetMoviesSpecification(request.SearchString));
            return new PaginatedList<Movie>(paginatedMovies.ToList(), totalItems, request.PageIndex, request.PageSize);
        }
    }
}
