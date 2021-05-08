using System;
using ApplicationCore.Common.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Threading;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.DirectorFeatures.Commands
{
    public sealed class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand, bool>
    {
        private readonly IAsyncRepository<Director> _asyncRepository;

        public DeleteDirectorCommandHandler(IAsyncRepository<Director> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<bool> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            var itemsNeedsToDelete = await _asyncRepository.GetByIdAsync(request.Id);
            if (itemsNeedsToDelete == null)
                return false;

            return await _asyncRepository.DeleteAsync(itemsNeedsToDelete);
        }
    }
}
