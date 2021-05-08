using ApplicationCore.Common.Models;
using ApplicationCore.Features.DirectorFeatures.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.ViewModels.Director;
using System;
using System.Threading.Tasks;

namespace MoviesWeb.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DirectorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DirectorController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<PaginatedList<DirectorViewModel>> GetDirectorsAsync(string prefix)
        {
            try
            {
                var actors = await _mediator.Send(new GetPaginatedDirectorsQuery(prefix, 1, Constants.ITEMS_PER_PAGE));
                var temp = _mapper.Map<PaginatedList<DirectorViewModel>>(actors);
                return temp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}