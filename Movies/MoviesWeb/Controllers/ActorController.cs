using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Features.ActorFeatures.Commands;
using ApplicationCore.Features.ActorFeatures.Queries;
using ApplicationCore.Paging;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.Utils;
using MoviesWeb.ViewModels.Actor;

namespace MoviesWeb.Controllers
{
    public class ActorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ActorController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ActionResult> Index([FromQuery] QueryParams searchQueryParams)
        {
            string searchString = string.Empty;
            int pageIndex = 1;
            int itemsPerPage = Constants.ITEMS_PER_PAGE;
            if (searchQueryParams != null)
            {
                searchString = searchQueryParams.SearchString;
                pageIndex = searchQueryParams.PageNumber;
                itemsPerPage = searchQueryParams.ItemsPerPage ?? itemsPerPage;
            }
            var paginatedActors = await _mediator.Send(new GetPaginatedActorsQuery(searchString, pageIndex, itemsPerPage));
            var actorIndexViewModel = new ActorIndexViewModel
            {
                Actors = _mapper.Map<List<ActorViewModel>>(paginatedActors.AsEnumerable<Actor>()),
                PaginationInfo = new ViewModels.PaginationInfoViewModel
                {
                    PageIndex = paginatedActors.PageIndex,
                    ItemsPerPage = paginatedActors.ItemsPerPage,
                    TotalPages = paginatedActors.TotalPages,
                    HasNextPage = paginatedActors.HasNextPage,
                    HasPreviousPage = paginatedActors.HasPreviousPage
                },
                SearchString = searchString
            };
            return View(actorIndexViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var actor = await _mediator.Send(new GetActorByIdQuery(id.Value));
            if (actor == null)
            {
                return NotFound();
            }
            var actorViewModel = _mapper.Map<ActorViewModel>(actor);
            return View(actorViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActorViewModel actorViewModel)
        {
            if (ModelState.IsValid)
            {
                string newFileName = FileUtil.SaveFileToPhysicalLocation(actorViewModel.Name, actorViewModel.Photo);
                actorViewModel.ImageUrl = Path.Combine("Images", newFileName);
                var actor = _mapper.Map<Actor>(actorViewModel);
                var updatedActor = await _mediator.Send(new CreateActorCommand(actor));
                return RedirectToAction(nameof(Index));
            }

            return View(actorViewModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var actor = await _mediator.Send(new GetActorByIdQuery(id.Value));
            if (actor == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<EditActorViewModel>(actor));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,ImageId,ImageUrl,Photo,Description")] EditActorViewModel actorViewModel)
        {
            if (id == null || id != actorViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (actorViewModel.Photo != null)
                {
                    var newFilePath = FileUtil.SaveFileToPhysicalLocation(actorViewModel.Name, actorViewModel.Photo);
                    actorViewModel.ImageUrl = Path.Combine("Images", newFilePath);
                }
                var actor = _mapper.Map<Actor>(actorViewModel);
                var updatedActor = await _mediator.Send(new UpdateActorCommand(actor));
                return RedirectToAction(nameof(Index));
            }
            return View(actorViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var actor = await _mediator.Send(new GetActorByIdQuery(id.Value));
                return actor != null ? View(_mapper.Map<ActorViewModel>(actor)) : (IActionResult)NotFound();
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isDeleted = await _mediator.Send(new DeleteActorCommand(id));
            return isDeleted ? RedirectToAction(nameof(Index)) : (IActionResult)NotFound();
        }
    }
}
