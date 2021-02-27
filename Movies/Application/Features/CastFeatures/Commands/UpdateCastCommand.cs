using System;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.CastFeatures.Commands
{
    public sealed class UpdateCastCommand : IRequest<MovieCast>
    {
        public MovieCast Cast { get; private set; }

        public UpdateCastCommand(MovieCast cast)
        {
            Cast = cast;
        }
    }
}
