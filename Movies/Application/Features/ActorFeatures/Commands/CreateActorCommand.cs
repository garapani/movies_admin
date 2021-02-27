using System;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.ActorFeatures.Commands
{
    public sealed class CreateActorCommand : IRequest<Actor>
    {
        public Actor Actor { get; private set; }

        public CreateActorCommand(Actor actor)
        {
            Actor = actor;
        }
    }
}
