using System;
using System.Threading.Tasks;
using ApplicationCore.Features.ActorFeatures.Queries;
using ApplicationCore.Paging;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.ViewModels.Actor;

namespace MoviesWeb.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ActorController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PaginatedList<ActorViewModel>> GetActorsAsync(string prefix)
        {
            try
            {
                var actors = await _mediator.Send(new GetPaginatedActorsQuery(prefix, 1, Constants.ITEMS_PER_PAGE));
                var temp = _mapper.Map<PaginatedList<ActorViewModel>>(actors);
                return temp;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}