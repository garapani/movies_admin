using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Specifications.CastSpecifications;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.CastFeatures.Queries
{
    public class GetCastDetailsByMovieIdQuery : IRequest<IReadOnlyList<MovieCast>>
    {
        public GetCastDetailsByMovieIdQuery(int movieId)
        {
            MovieId = movieId;
        }

        public int MovieId { get; set; }
    }

    public class GetCastDetailsByMovieIdQueryHandle : IRequestHandler<GetCastDetailsByMovieIdQuery, IReadOnlyList<MovieCast>>
    {
        private readonly IAsyncRepository<MovieCast> _repositoryAsync;

        public GetCastDetailsByMovieIdQueryHandle(IAsyncRepository<MovieCast> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<IReadOnlyList<MovieCast>> Handle(GetCastDetailsByMovieIdQuery request, CancellationToken cancellationToken)
        {
            return await _repositoryAsync.ListAsync(new GetCastWithItemsUsingMovieIdSpecification(request.MovieId));
        }
    }
}