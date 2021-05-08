using System;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.DirectorFeatures.Commands
{
    public sealed class CreateDirectorCommand : IRequest<Director>
    {
        public Director Director { get; private set; }

        public CreateDirectorCommand(Director director)
        {
            Director = director;
        }
    }
}
