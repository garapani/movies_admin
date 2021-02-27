using System;
using MediatR;
using Domain.Entity;

namespace ApplicationCore.Features.DirectorFeatures.Commands
{
    public sealed class DeleteDirectorCommand : IRequest<bool>
    {
        public int Id { get; private set; }

        public DeleteDirectorCommand(int id)
        {
            Id = id;
        }
    }
}
