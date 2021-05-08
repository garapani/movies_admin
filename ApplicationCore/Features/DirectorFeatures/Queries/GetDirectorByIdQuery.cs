using System;
using Domain.Entity;
using MediatR;

namespace ApplicationCore.Features.DirectorFeatures.Queries
{
    public class GetDirectorByIdQuery : IRequest<Director>
    {
        public GetDirectorByIdQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
