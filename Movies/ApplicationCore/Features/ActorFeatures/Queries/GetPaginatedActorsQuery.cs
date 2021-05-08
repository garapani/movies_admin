using ApplicationCore.Common.Models;
using Domain.Entity;
using MediatR;

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
}
