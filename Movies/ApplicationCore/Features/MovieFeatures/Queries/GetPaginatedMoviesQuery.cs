using ApplicationCore.Common.Models;
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
}
