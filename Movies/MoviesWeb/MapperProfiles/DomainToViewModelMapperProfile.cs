using ApplicationCore.Paging;
using AutoMapper;
using Domain.Entity;
using MoviesWeb.ViewModels.Actor;
using MoviesWeb.ViewModels.Director;
using MoviesWeb.ViewModels.Movie;
using MoviesWeb.ViewModels.MovieCast;
using System.Collections.Generic;

namespace MoviesWeb.MapperProfiles
{
    public class DomainToViewModelMapperProfile : Profile
    {
        public DomainToViewModelMapperProfile()
        {
            CreateMap<Actor, ActorViewModel>();
            CreateMap<Actor[], IEnumerable<ActorViewModel>>();
            CreateMap<Actor, EditActorViewModel>();
            CreateMap<PaginatedList<Actor>, PaginatedList<ActorViewModel>>();

            CreateMap<Director, DirectorViewModel>();
            CreateMap<Director[], IEnumerable<DirectorViewModel>>();
            CreateMap<Director, EditDirectorViewModel>();
            CreateMap<PaginatedList<Director>, PaginatedList<DirectorViewModel>>();

            CreateMap<Movie, MovieViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl));
            CreateMap<Movie[], IEnumerable<MovieViewModel>>();
            CreateMap<Movie, EditMovieViewModel>();
            CreateMap<PaginatedList<Movie>, PaginatedList<MovieViewModel>>();

            CreateMap<MovieActor, MovieCastViewModel>();
            CreateMap<MovieActor[], IEnumerable<MovieCastViewModel>>();
            CreateMap<PaginatedList<MovieActor>, PaginatedList<MovieCastViewModel>>();
        }
    }
}
