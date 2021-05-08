using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.ActorFeatures.Queries
{
    public class GetActorByIdQuery : IRequest<Actor>
    {
        public GetActorByIdQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
