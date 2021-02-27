using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Features.ActorFeatures.Queries;
using ApplicationCore.Features.CastFeatures.Commands;
using ApplicationCore.Features.CastFeatures.Queries;
using ApplicationCore.Features.MovieFeatures.Queries;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoviesWeb.ViewModels.Movie;
using MoviesWeb.ViewModels.MovieCast;

namespace MoviesWeb.Controllers
{
    public class CastController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CastController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(int movieId)
        {
            var movieDetails = await _mediator.Send(new GetMovieByIdQuery(movieId));
            var movieViewModel = _mapper.Map<MovieViewModel>(movieDetails);
            var castDetails = await _mediator.Send(new GetCastDetailsByMovieIdQuery(movieId));
            var movieCastViewModel = _mapper.Map<IEnumerable<MovieCastViewModel>>(castDetails.ToList());
            var movieCastIndexViewModel = new MovieCastIndexViewModel
            {
                Movie = movieViewModel,
                Cast = movieCastViewModel
            };
            return View(movieCastIndexViewModel);
        }

        public async Task<IActionResult> Edit(int movieId, int actorId)
        {
            var castDetails = await _mediator.Send(new GetCastDetailsQuery(movieId, actorId));
            var movieCastViewModel = _mapper.Map<MovieCastViewModel>(castDetails);
            return View(movieCastViewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? movieId, int? actorId, MovieCastViewModel movieCastViewModel)
        {
            if (movieId == null || movieId != movieCastViewModel.MovieId || actorId == null || actorId != movieCastViewModel.ActorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var cast = _mapper.Map<MovieCast>(movieCastViewModel);
                var updatedCast = await _mediator.Send(new UpdateCastCommand(cast));
                return RedirectToAction(nameof(Index), new RouteValueDictionary(new { movieCastViewModel.MovieId }));
            }
            return View(movieCastViewModel);
        }

        public async Task<IActionResult> Create(int? movieId)
        {
            if (movieId == null)
                return NotFound();
            var movieDetails = await _mediator.Send(new GetMovieByIdQuery(movieId.Value));
            var movieCastViewModel = new MovieCastCreateViewModel() { MovieId = movieId.Value, MovieTitle = movieDetails.Title, MovieImageUrl = movieDetails.Image.ImageUrl };
            return View(movieCastViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? movieId, MovieCastCreateViewModel movieCastCreateViewModel)
        {
            if (movieId == null)
                return NotFound();
            if (!ModelState.IsValid)
            {
                return View(movieCastCreateViewModel);
            }
            var castDetails = await _mediator.Send(new GetCastDetailsByMovieIdQuery(movieId.Value));
            if (castDetails != null)
            {
                if (castDetails.FirstOrDefault(c => c.ActorId == movieCastCreateViewModel.ActorId) != null)
                {
                    ModelState.AddModelError("ActorId", "Actor is already present as cast.So please select other actor");
                    return View(movieCastCreateViewModel);
                    //return RedirectToAction(nameof(Create), new RouteValueDictionary(new { movieId = movieId.Value }));
                }
            }

            var movieCast = _mapper.Map<MovieCast>(movieCastCreateViewModel);
            var movie = await _mediator.Send(new GetMovieByIdQuery(movieCast.MovieId));
            var actor = await _mediator.Send(new GetActorByIdQuery(movieCast.ActorId));
            movieCast.Movie = movie;
            movieCast.Actor = actor;
            var createdCast = await _mediator.Send(new CreateCastCommand(movieCast));
            return RedirectToAction(nameof(Index), new RouteValueDictionary(new { createdCast.MovieId }));
        }
        // GET: CastController/Delete?actorId=5&moveId=5
        public async Task<IActionResult> Delete(int? actorId, int? movieId)
        {
            if (actorId != null && movieId != null)
            {
                var movieCast = await _mediator.Send(new GetCastDetailsQuery(movieId.Value, actorId.Value));
                return movieCast != null ? View(_mapper.Map<MovieCastViewModel>(movieCast)) : (IActionResult)NotFound();
            }
            return NotFound();
        }

        // POST: MovieController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int actorId, int movieId, IFormCollection collection)
        {
            var isDeleted = await _mediator.Send(new DeleteCastCommand(movieId, actorId));
            return isDeleted ? RedirectToAction(nameof(Index), new { movieId = movieId }) : (IActionResult)NotFound();
        }
    }
}
