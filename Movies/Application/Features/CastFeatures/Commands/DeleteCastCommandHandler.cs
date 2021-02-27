using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Specifications.CastSpecifications;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.CastFeatures.Commands
{
    public sealed class DeleteCastCommandHandler : IRequestHandler<DeleteCastCommand, bool>
    {
        private readonly IAsyncRepository<MovieCast> _repositoryAsync;
        public DeleteCastCommandHandler(IAsyncRepository<MovieCast> asyncRepository)
        {
            _repositoryAsync = asyncRepository;
        }

        public async Task<bool> Handle(DeleteCastCommand request, CancellationToken cancellationToken)
        {
            var castDetails = await _repositoryAsync.FirstOrDefaultAsync(new GetCastWithItemsSpecification(request.MovieId, request.ActorId));
            if (castDetails == null)
                return false;
            return await _repositoryAsync.DeleteAsync(castDetails);
        }
    }
}
