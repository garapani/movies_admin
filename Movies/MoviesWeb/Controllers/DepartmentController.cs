using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MoviesWeb.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IActionResult Index()
        {
            //var actors = await _mediator.Send(new GetActorListQuery(actualPage, Constants.ITEMS_PER_PAGE, searchString));
            //var actorsTotalCount = await _mediator.Send(new GetActorsCountQuery());
            //var totalPages = int.Parse(Math.Ceiling(((decimal)actorsTotalCount / Constants.ITEMS_PER_PAGE)).ToString());
            //var actorsViewModel = _mapper.Map<IEnumerable<ActorViewModel>>(actors);
            //var actorIndexViewModel = new ActorIndexViewModel
            //{
            //    Actors = actorsViewModel.ToList(),
            //    PaginationInfo = new ViewModels.PaginationInfoViewModel
            //    {
            //        TotalItems = actorsTotalCount,
            //        ActualPage = actualPage,
            //        ItemsPerPage = Constants.ITEMS_PER_PAGE,
            //        TotalPages = totalPages,
            //        HasNextPage = actualPage < totalPages - 1,
            //        HasPreviousPage = actualPage > 0
            //    },
            //    SearchString = searchString
            //};
            //return View(actorIndexViewModel);
            return View();
        }
    }
}
