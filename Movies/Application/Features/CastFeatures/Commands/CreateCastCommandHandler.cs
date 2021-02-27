using System;
using Domain.Entity;
using MediatR;
using ApplicationCore.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.CastFeatures.Commands
{
    public sealed class CreateCastCommandHandler : IRequestHandler<CreateCastCommand, MovieCast>
    {
        private readonly IAsyncRepository<MovieCast> _castRepository;

        public CreateCastCommandHandler(IAsyncRepository<MovieCast> castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<MovieCast> Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            return await _castRepository.AddAsync(request.Cast);
        }
    }
}
