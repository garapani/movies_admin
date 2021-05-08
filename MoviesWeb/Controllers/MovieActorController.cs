using ApplicationCore.Features.MovieActorFeature.Commands;
using ApplicationCore.Features.MovieActorFeature.Queries;
using ApplicationCore.Features.MovieFeatures.Queries;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoviesWeb.ViewModels.Movie;
using MoviesWeb.ViewModels.MovieActor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesWeb.Controllers
{
    [Authorize]
    public class MovieActorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MovieActorController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int movieId)
        {
            var movieDetails = await _mediator.Send(new GetMovieByIdQuery(movieId));
            var movieViewModel = _mapper.Map<MovieViewModel>(movieDetails);
            var movieCastIndexViewModel = new MovieActorIndexViewModel
            {
                Movie = movieViewModel,
                MovieActors = _mapper.Map<List<MovieActorViewModel>>(movieDetails.MovieActors)
            };
            return View(movieCastIndexViewModel);
        }

        public async Task<IActionResult> Edit(int movieId, int actorId)
        {
            var castDetails = await _mediator.Send(new GetMovieActorDetailsQuery(movieId, actorId));
            var movieCastViewModel = _mapper.Map<EditMovieActorViewModel>(castDetails);
            return View(movieCastViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? movieId, int? actorId, MovieActorViewModel movieCastViewModel)
        {
            if (movieId == null || movieId != movieCastViewModel.MovieId || actorId == null || actorId != movieCastViewModel.ActorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var cast = _mapper.Map<MovieActor>(movieCastViewModel);
                var updatedCast = await _mediator.Send(new UpdateMovieActorCommand(cast));
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { movieCastViewModel.MovieId }));
            }
            return View(movieCastViewModel);
        }

        public async Task<IActionResult> Create(int? movieId)
        {
            if (movieId == null)
                return NotFound();
            var movieDetails = await _mediator.Send(new GetMovieByIdQuery(movieId.Value));
            var movieCastViewModel = new MovieActorCreateViewModel() { MovieId = movieId.Value, MovieTitle = movieDetails.Title, MovieImageUrl = movieDetails.Image.ImageUrl };
            return View(movieCastViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? movieId, MovieActorCreateViewModel movieCastCreateViewModel)
        {
            if (movieId == null)
                return NotFound();
            if (!ModelState.IsValid)
            {
                return View(movieCastCreateViewModel);
            }
            var castDetails = await _mediator.Send(new GetMovieActorDetailsQuery(movieId.Value, movieCastCreateViewModel.ActorId));

            if (castDetails != null)
            {
                ModelState.AddModelError("ActorId", "Actor is already present as cast.So please select other actor");
                return View(movieCastCreateViewModel);
            }

            var movieCast = _mapper.Map<MovieActor>(movieCastCreateViewModel);
            var movie = await _mediator.Send(new CreateMovieActorCommand(movieCast));
            return RedirectToAction(nameof(Index), new { movieId = movieId });
        }

        // GET: CastController/Delete?actorId=5&moveId=5
        public async Task<IActionResult> Delete(int? actorId, int? movieId)
        {
            if (actorId != null && movieId != null)
            {
                var movieCast = await _mediator.Send(new GetMovieActorDetailsQuery(movieId.Value, actorId.Value));
                return movieCast != null ? View(_mapper.Map<MovieActorViewModel>(movieCast)) : (IActionResult)NotFound();
            }
            return NotFound();
        }

        // POST: MovieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int actorId, int movieId, IFormCollection collection)
        {
            var isDeleted = await _mediator.Send(new DeleteMovieActorCommand(movieId, actorId));
            return isDeleted ? RedirectToAction(nameof(Index), new { movieId = movieId }) : (IActionResult)NotFound();
        }
    }
}
