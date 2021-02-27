using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.MovieFeatures.Queries
{
    public class GetMovieByIdQuery : IRequest<Movie>
    {
        public GetMovieByIdQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
