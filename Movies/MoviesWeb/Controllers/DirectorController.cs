using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Features.DirectorFeatures.Queries;
using ApplicationCore.Features.DirectorFeatures.Commands;
using ApplicationCore.Paging;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.Utils;
using MoviesWeb.ViewModels.Director;

namespace MoviesWeb.Controllers
{
    public class DirectorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DirectorController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ActionResult> Index([FromQuery] QueryParams searchQueryParams)
        {
            string searchString = string.Empty;
            int pageIndex = 0;
            int itemsPerPage = Constants.ITEMS_PER_PAGE;
            if (searchQueryParams != null)
            {
                int.TryParse(searchQueryParams.PageId, out pageIndex);
                searchString = searchQueryParams.SearchString;
                itemsPerPage = Constants.ITEMS_PER_PAGE;
            }

            var paginatedDirectors = await _mediator.Send(new GetPaginatedDirectorsQuery(searchString, pageIndex, itemsPerPage));

            var directorIndexViewModel = new DirectorIndexViewModel
            {
                Directors = _mapper.Map<List<DirectorViewModel>>(paginatedDirectors.AsEnumerable<Director>()),
                PaginationInfo = new ViewModels.PaginationInfoViewModel
                {
                    PageIndex = paginatedDirectors.PageIndex,
                    ItemsPerPage = paginatedDirectors.ItemsPerPage,
                    TotalPages = paginatedDirectors.TotalPages,
                    HasNextPage = paginatedDirectors.HasNextPage,
                    HasPreviousPage = paginatedDirectors.HasPreviousPage
                },
                SearchString = searchString
            };
            return View(directorIndexViewModel);
        }

        // GET: Director/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var director = await _mediator.Send(new GetDirectorByIdQuery(id.Value));
            if (director == null)
            {
                return NotFound();
            }
            var directorViewModel = _mapper.Map<DirectorViewModel>(director);
            return View(directorViewModel);
        }

        // GET: Director/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DirectorViewModel directorViewModel)
        {
            if (ModelState.IsValid)
            {
                string newFileName = FileUtil.SaveFileToPhysicalLocation(directorViewModel.Name, directorViewModel.Photo);
                directorViewModel.ImageUrl = Path.Combine("Images", newFileName);
                var director = _mapper.Map<Director>(directorViewModel);
                var updatedDirector = await _mediator.Send(new CreateDirectorCommand(director));
                return RedirectToAction(nameof(Index));
            }

            return View(directorViewModel);
        }

        // GET: Director/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var director = await _mediator.Send(new GetDirectorByIdQuery(id.Value));
            if (director == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<EditDirectorViewModel>(director));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,ImageId,ImageUrl,Photo,Description")] EditDirectorViewModel directorViewModel)
        {
            if (id == null || id != directorViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (directorViewModel.Photo != null)
                {
                    var newFilePath = FileUtil.SaveFileToPhysicalLocation(directorViewModel.Name, directorViewModel.Photo);
                    directorViewModel.ImageUrl = Path.Combine("Images", newFilePath);
                }
                var director = _mapper.Map<Director>(directorViewModel);
                var updatedDirector = await _mediator.Send(new UpdateDirectorCommand(director));
                return RedirectToAction(nameof(Index));
            }
            return View(directorViewModel);
        }

        // GET: Director/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var director = await _mediator.Send(new GetDirectorByIdQuery(id.Value));
                return director != null ? View(_mapper.Map<DirectorViewModel>(director)) : (IActionResult)NotFound();
            }
            return NotFound();
        }

        // POST: Director/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isDeleted = await _mediator.Send(new DeleteDirectorCommand(id));
            return isDeleted ? RedirectToAction(nameof(Index)) : (IActionResult)NotFound();
        }
    }
}