using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Specifications.MovieSpecifications;
using Domain.Entity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.MovieDirectorFeature.Queries
{
    public class GetMovieDirectorDetailsQueryHandler : IRequestHandler<GetMovieDirectorDetailsQuery, MovieDirector>
    {
        private readonly IAsyncRepository<Movie> _asyncRepository;
        public GetMovieDirectorDetailsQueryHandler(IAsyncRepository<Movie> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<MovieDirector> Handle(GetMovieDirectorDetailsQuery request, CancellationToken cancellationToken)
        {
            var movieDetails = await _asyncRepository.FirstOrDefaultAsync(new GetMovieWithItemsSpecification(request.MovieId));
            return movieDetails.MovieDirectors.FirstOrDefault(ma => ma.DirectorId == request.DirectorId);
        }
    }
}
