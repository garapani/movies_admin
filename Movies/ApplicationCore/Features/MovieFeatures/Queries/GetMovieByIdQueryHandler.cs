using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Specifications.MovieSpecifications;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieFeatures.Queries
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly IAsyncRepository<Movie> _asyncRepository;
        public GetMovieByIdQueryHandler(IAsyncRepository<Movie> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {

            return await _asyncRepository.FirstOrDefaultAsync(new GetMovieWithItemsSpecification(request.Id));
        }
    }
}
