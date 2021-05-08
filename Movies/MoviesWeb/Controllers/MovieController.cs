using ApplicationCore.Common.Models;
using ApplicationCore.Features.MovieFeatures.Commands;
using ApplicationCore.Features.MovieFeatures.Queries;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.Utils;
using MoviesWeb.ViewModels.Movie;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWeb.Controllers
{
    [Authorize]
    public class MovieController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MovieController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: MovieController
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
            var paginatedMovies = await _mediator.Send(new GetPaginatedMoviesQuery(searchString, pageIndex, itemsPerPage));

            var movieIndexViewModel = new MovieIndexViewModel
            {
                Movies = _mapper.Map<List<MovieViewModel>>(paginatedMovies.AsEnumerable<Movie>()),
                PaginationInfo = new ViewModels.PaginationInfoViewModel
                {
                    PageIndex = paginatedMovies.PageIndex,
                    ItemsPerPage = paginatedMovies.ItemsPerPage,
                    TotalPages = paginatedMovies.TotalPages,
                    HasNextPage = paginatedMovies.HasNextPage,
                    HasPreviousPage = paginatedMovies.HasPreviousPage
                },
                SearchString = searchString
            };
            return View(movieIndexViewModel);
        }

        // GET: MovieController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = await _mediator.Send(new GetMovieByIdQuery(id.Value));
            if (movie == null)
            {
                return NotFound();
            }
            var movieDetailsViewModel = _mapper.Map<MovieViewModel>(movie);
            return View(movieDetailsViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel movieViewModel)
        {
            if (ModelState.IsValid)
            {
                string newFileName = FileUtil.SaveFileToPhysicalLocation(movieViewModel.Title, movieViewModel.Photo);
                movieViewModel.ImageUrl = Path.Combine("Images", newFileName);
                var movie = _mapper.Map<Movie>(movieViewModel);
                var updatedMovie = await _mediator.Send(new CreateMovieCommand(movie));
                return RedirectToAction(nameof(Index));
            }

            return View(movieViewModel);
        }

        // GET: MovieController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = await _mediator.Send(new GetMovieByIdQuery(id.Value));
            if (movie == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<EditMovieViewModel>(movie));
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, EditMovieViewModel movieViewModel)
        {
            if (id == null || id != movieViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (movieViewModel.Photo != null)
                {
                    FileUtil.DeleteFile(movieViewModel.ImageUrl);
                    var newFilePath = FileUtil.SaveFileToPhysicalLocation(movieViewModel.Title, movieViewModel.Photo);
                    movieViewModel.ImageUrl = Path.Combine("Images", newFilePath);
                }
                var movie = _mapper.Map<Movie>(movieViewModel);
                var updatedMovie = await _mediator.Send(new UpdateMovieCommand(movie));
                return RedirectToAction(nameof(Index));
            }
            return View(movieViewModel);
        }

        // GET: MovieController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var movie = await _mediator.Send(new GetMovieByIdQuery(id.Value));
                return movie != null ? View(_mapper.Map<MovieViewModel>(movie)) : (IActionResult)NotFound();
            }
            return NotFound();
        }

        // POST: MovieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, IFormCollection collection)
        {
            var isDeleted = await _mediator.Send(new DeleteMovieCommand(id));
            return isDeleted ? RedirectToAction(nameof(Index)) : (IActionResult)NotFound();
        }
    }
}
