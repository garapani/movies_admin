using ApplicationCore.Common.Models;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.DirectorFeatures.Queries
{
    public class GetPaginatedDirectorsQuery : IRequest<PaginatedList<Director>>
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
}
