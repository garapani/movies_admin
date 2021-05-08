using ApplicationCore.Common.Models;
using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Specifications.MovieSpecifications;
using Domain.Entity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.MovieFeatures.Queries
{
    public class GetPaginatedMoviesQueryHandler : IRequestHandler<GetPaginatedMoviesQuery, PaginatedList<Movie>>
    {
        private readonly IAsyncRepository<Movie> _repositoryAsync;

        public GetPaginatedMoviesQueryHandler(IAsyncRepository<Movie> repositoryAsync)
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
