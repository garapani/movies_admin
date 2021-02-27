using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.ImageFeatures.Commands
{
    public class CreateImageCommand : IRequest<Image>
    {
        public Image Image { get; private set; }
        public CreateImageCommand(Image image)
        {
            Image = image;
        }
    }
}
