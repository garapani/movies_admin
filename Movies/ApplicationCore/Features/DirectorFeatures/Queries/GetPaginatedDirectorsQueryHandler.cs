using ApplicationCore.Common.Models;
using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Specifications.DirectorSpecifications;
using Domain.Entity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.DirectorFeatures.Queries
{
    public class GetPaginatedDirectorsQueryHandler : IRequestHandler<GetPaginatedDirectorsQuery, PaginatedList<Director>>
    {
        private readonly IAsyncRepository<Director> _repositoryAsync;

        public GetPaginatedDirectorsQueryHandler(IAsyncRepository<Director> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<PaginatedList<Director>> Handle(GetPaginatedDirectorsQuery request, CancellationToken cancellationToken)
        {
            var paginatedDirectors = await _repositoryAsync.ListAsync(new GetPaginatedDirectorsWithItemsSpecfication(request.SearchString, request.PageIndex, request.PageSize));
            var totalItems = await _repositoryAsync.CountAsync(new GetDirectorsSpecification(request.SearchString));
            return new PaginatedList<Director>(paginatedDirectors.ToList(), totalItems, request.PageIndex, request.PageSize);
        }
    }
}
