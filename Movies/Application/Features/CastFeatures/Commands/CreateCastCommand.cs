using System;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.CastFeatures.Commands
{
    public sealed class CreateCastCommand : IRequest<MovieCast>
    {
        public MovieCast Cast { get; private set; }

        public CreateCastCommand(MovieCast cast)
        {
            Cast = cast;
        }
    }
}
