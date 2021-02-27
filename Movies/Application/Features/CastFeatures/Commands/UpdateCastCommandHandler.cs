using System;
using MediatR;
using Domain.Entity;
using ApplicationCore.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.CastFeatures.Commands
{
    public sealed class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand, MovieCast>
    {
        private readonly IAsyncRepository<MovieCast> _asyncRepository;
        public UpdateCastCommandHandler(IAsyncRepository<MovieCast> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<MovieCast> Handle(UpdateCastCommand request, CancellationToken cancellationToken) => await _asyncRepository.UpdateAsync(request.Cast);
    }
}
