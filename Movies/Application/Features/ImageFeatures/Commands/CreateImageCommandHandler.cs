using ApplicationCore.Interfaces.Repositories;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.ImageFeatures.Commands
{
    public sealed class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, Image>
    {
        private readonly IAsyncRepository<Image> _imageRepository;

        public CreateImageCommandHandler(IAsyncRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<Image> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            return await _imageRepository.AddAsync(request.Image);
        }
    }
}
