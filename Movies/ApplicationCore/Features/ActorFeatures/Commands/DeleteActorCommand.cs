using MediatR;

namespace ApplicationCore.Features.ActorFeatures.Commands
{
    public sealed class DeleteActorCommand : IRequest<bool>
    {
        public int Id { get; private set; }

        public DeleteActorCommand(int id)
        {
            Id = id;
        }
    }
}
