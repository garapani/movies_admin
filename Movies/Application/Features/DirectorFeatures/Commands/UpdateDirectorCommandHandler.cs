using System;
using Domain.Entity;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using MediatR;

namespace ApplicationCore.Features.DirectorFeatures.Commands
{

    public sealed class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand, Director>
    {
        private readonly IAsyncRepository<Director> _asyncRepository;
        public UpdateDirectorCommandHandler(IAsyncRepository<Director> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<Director> Handle(UpdateDirectorCommand request, CancellationToken cancellationToken) => await _asyncRepository.UpdateAsync(request.Director);
    }
}
