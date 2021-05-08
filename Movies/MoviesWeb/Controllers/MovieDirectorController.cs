using ApplicationCore.Features.MovieDirectorFeature.Commands;
using ApplicationCore.Features.MovieDirectorFeature.Queries;
using ApplicationCore.Features.MovieFeatures.Queries;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWeb.ViewModels.Movie;
using MoviesWeb.ViewModels.MovieDirector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesWeb.Controllers
{
    [Authorize]
    public class MovieDirectorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MovieDirectorController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int movieId)
        {
            var movieDetails = await _mediator.Send(new GetMovieByIdQuery(movieId));
            var movieViewModel = _mapper.Map<MovieViewModel>(movieDetails);
            var movieDirectorIndexViewModel = new MovieDirectorIndexViewModel
            {
                Movie = movieViewModel,
                MovieDirectors = _mapper.Map<List<MovieDirectorViewModel>>(movieDetails.MovieDirectors)
            };
            return View(movieDirectorIndexViewModel);
        }

        public async Task<IActionResult> Create(int? movieId)
        {
            if (movieId == null)
                return NotFound();
            var movieDetails = await _mediator.Send(new GetMovieByIdQuery(movieId.Value));
            var movieDirectorViewModel = new MovieDirectorCreateViewModel() { MovieId = movieId.Value, MovieTitle = movieDetails.Title, MovieImageUrl = movieDetails.Image.ImageUrl };
            return View(movieDirectorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? movieId, MovieDirectorCreateViewModel movieDirectorCreateViewModel)
        {
            if (movieId == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                return View(movieDirectorCreateViewModel);
            }

            var movieDirectorDetails = await _mediator.Send(new GetMovieDirectorDetailsQuery(movieId.Value, movieDirectorCreateViewModel.DirectorId));

            if (movieDirectorDetails != null)
            {
                ModelState.AddModelError("DirectorId", "Director is already present in Directors.So please select other director");
                return View(movieDirectorCreateViewModel);
            }

            var movieDirector = _mapper.Map<MovieDirector>(movieDirectorCreateViewModel);
            var movie = await _mediator.Send(new CreateMovieDirectorCommand(movieDirector));
            return RedirectToAction(nameof(Index), new { movieId = movieId });
        }

        // GET: DirectorController/Delete?directorId=5&moveId=5
        public async Task<IActionResult> Delete(int? directorId, int? movieId)
        {
            if (directorId != null && movieId != null)
            {
                var movieDirector = await _mediator.Send(new GetMovieDirectorDetailsQuery(movieId.Value, directorId.Value));
                return movieDirector != null ? View(_mapper.Map<MovieDirectorViewModel>(movieDirector)) : (IActionResult)NotFound();
            }
            return NotFound();
        }

        // POST: DirectorController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int directorId, int movieId, IFormCollection collection)
        {
            var isDeleted = await _mediator.Send(new DeleteMovieDirectorCommand(movieId, directorId));
            return isDeleted ? RedirectToAction(nameof(Index), new { movieId = movieId }) : (IActionResult)NotFound();
        }
    }
}
