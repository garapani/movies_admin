using System;
using MediatR;
using Domain.Entity;

namespace ApplicationCore.Features.DirectorFeatures.Commands
{
    public sealed class UpdateDirectorCommand : IRequest<Director>
    {
        public Director Director { get; private set; }

        public UpdateDirectorCommand(Director director)
        {
            Director = director;
        }
    }
}
