using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Common.Interfaces.Repositories;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.ActorFeatures.Commands
{
    public sealed class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, Actor>
    {
        private readonly IAsyncRepository<Actor> _asyncRepository;
        public UpdateActorCommandHandler(IAsyncRepository<Actor> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<Actor> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
        {
            return await _asyncRepository.UpdateAsync(request.Actor);
        }
    }
}
