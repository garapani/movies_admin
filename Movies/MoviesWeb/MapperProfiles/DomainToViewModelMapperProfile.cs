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
            CreateMap<PaginatedList<Actor>, PaginatedList<ActorViewModel>>();
            CreateMap<Actor, EditActorViewModel>();

            CreateMap<Director, DirectorViewModel>();
            CreateMap<Director[], IEnumerable<DirectorViewModel>>();
            CreateMap<PaginatedList<Director>, PaginatedList<DirectorViewModel>>();
            CreateMap<Director, EditDirectorViewModel>();

            CreateMap<Movie, MovieViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl));
            CreateMap<Movie[], IEnumerable<MovieViewModel>>();
            CreateMap<PaginatedList<Movie>, PaginatedList<MovieViewModel>>();
            CreateMap<Movie, EditMovieViewModel>();

            CreateMap<MovieCast, MovieCastViewModel>();
            CreateMap<MovieCast[], IEnumerable<MovieCastViewModel>>();
            CreateMap<PaginatedList<MovieCast>, PaginatedList<MovieCastViewModel>>();
        }
    }
}
