using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.ActorFeatures.Queries
{
    public class GetActorByIdQueryHandler : IRequestHandler<GetActorByIdQuery, Actor>
    {
        private readonly IAsyncRepository<Actor> _asyncRepository;
        public GetActorByIdQueryHandler(IAsyncRepository<Actor> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<Actor> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _asyncRepository.GetByIdAsync(request.Id);
        }
    }
}
