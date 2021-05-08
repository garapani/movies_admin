using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Common.Interfaces.Repositories;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.ActorFeatures.Commands
{
    public sealed class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, Actor>
    {
        private readonly IAsyncRepository<Actor> _actorRepository;

        public CreateActorCommandHandler(IAsyncRepository<Actor> actorRepository)
        {
            _actorRepository = actorRepository;
        }

        public async Task<Actor> Handle(CreateActorCommand request, CancellationToken cancellationToken)
        {
            return await _actorRepository.AddAsync(request.Actor);
        }
    }
}
