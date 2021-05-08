using ApplicationCore.Common.Interfaces.Repositories;
using ApplicationCore.Specifications.ActorSpecifications;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
            return await _asyncRepository.FirstOrDefaultAsync(new GetActorWithItemsSpecification(request.Id));
        }
    }
}
