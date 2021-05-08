using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.ActorFeatures.Commands
{
    public sealed class UpdateActorCommand : IRequest<Actor>
    {
        public Actor Actor { get; private set; }

        public UpdateActorCommand(Actor actor)
        {
            Actor = actor;
        }
    }
}
