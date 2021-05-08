using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Common.Interfaces.Services;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.MovieFeatures.Commands
{
    public sealed class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, bool>
    {
        private readonly IAsyncRepository<Movie> _asyncRepository;
        private readonly IDomainEventService _domainEventService;

        public DeleteMovieCommandHandler(IAsyncRepository<Movie> asyncRepository, IDomainEventService domainEventService)
        {
            _asyncRepository = asyncRepository;
            _domainEventService = domainEventService;
        }

        public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            var itemsNeedsToDelete = await _asyncRepository.GetByIdAsync(request.Id);
            if (itemsNeedsToDelete == null)
                return false;
            return await _asyncRepository.DeleteAsync(itemsNeedsToDelete);
        }
    }
}
