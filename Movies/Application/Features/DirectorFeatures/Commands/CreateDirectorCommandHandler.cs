using System;
using MediatR;
using Domain.Entity;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;

namespace ApplicationCore.Features.DirectorFeatures.Commands
{
    public sealed class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, Director>
    {
        private readonly IAsyncRepository<Director> _directorRepository;

        public CreateDirectorCommandHandler(IAsyncRepository<Director> directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<Director> Handle(CreateDirectorCommand request, CancellationToken cancellationToken) => await _directorRepository.AddAsync(request.Director);
    }
}
