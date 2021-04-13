using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.ActorFeatures.Commands
{
    public sealed class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand, bool>
    {
        private readonly IAsyncRepository<Actor> _asyncRepository;

        public DeleteActorCommandHandler(IAsyncRepository<Actor> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<bool> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
        {
            var itemsNeedsToDelete = await _asyncRepository.GetByIdAsync(request.Id);
            if (itemsNeedsToDelete == null)
                return false;

            return await _asyncRepository.DeleteAsync(itemsNeedsToDelete);
        }
    }
}
