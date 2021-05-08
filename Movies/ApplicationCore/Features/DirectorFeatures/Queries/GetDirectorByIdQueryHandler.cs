using ApplicationCore.Common.Interfaces.Repositories;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.DirectorFeatures.Queries
{
    public class GetDirectorByIdQueryHandler : IRequestHandler<GetDirectorByIdQuery, Director>
    {
        private readonly IAsyncRepository<Director> _asyncRepository;
        public GetDirectorByIdQueryHandler(IAsyncRepository<Director> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<Director> Handle(GetDirectorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _asyncRepository.GetByIdAsync(request.Id);
        }
    }
}
