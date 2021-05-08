using System;
using MediatR;
using Domain.Entity;

namespace ApplicationCore.Features.MovieFeatures.Commands
{
    public sealed class UpdateMovieCommand : IRequest<Movie>
    {
        public Movie Movie { get; private set; }

        public UpdateMovieCommand(Movie movie)
        {
            Movie = movie;
        }
    }
}
