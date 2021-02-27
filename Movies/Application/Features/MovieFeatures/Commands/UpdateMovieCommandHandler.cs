using System;
using Domain.Entity;
using ApplicationCore.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Features.MovieFeatures.Commands
{
    public sealed class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Movie>
    {
        private readonly IAsyncRepository<Movie> _asyncRepository;
        public UpdateMovieCommandHandler(IAsyncRepository<Movie> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task<Movie> Handle(UpdateMovieCommand request, CancellationToken cancellationToken) => await _asyncRepository.UpdateAsync(request.Movie);
    }
}
