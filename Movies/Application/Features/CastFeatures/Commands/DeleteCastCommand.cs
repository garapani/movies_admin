using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Interfaces.Repositories;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.CastFeatures.Commands
{
    public class DeleteCastCommand : IRequest<bool>
    {
        public DeleteCastCommand(int movieId, int actorId)
        {
            MovieId = movieId;
            ActorId = actorId;
        }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
    }
}