using MediatR;

namespace ApplicationCore.Features.MovieFeatures.Commands
{
    public sealed class DeleteMovieCommand : IRequest<bool>
    {
        public int Id { get; private set; }

        public DeleteMovieCommand(int id)
        {
            Id = id;
        }
    }
}
