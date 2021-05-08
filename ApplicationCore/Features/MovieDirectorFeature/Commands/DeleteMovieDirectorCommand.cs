using MediatR;

namespace ApplicationCore.Features.MovieDirectorFeature.Commands
{
    public sealed class DeleteMovieDirectorCommand : IRequest<bool>
    {
        public int MovieId { get; private set; }
        public int DirectorId { get; private set; }

        public DeleteMovieDirectorCommand(int movieId, int directorId)
        {
            MovieId = movieId;
            DirectorId = directorId;
        }

        public DeleteMovieDirectorCommand(int movieId)
        {
            MovieId = movieId;
        }
    }
}
