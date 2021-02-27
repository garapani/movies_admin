using AutoMapper;
using Domain.Entity;
using MoviesWeb.ViewModels.Actor;
using MoviesWeb.ViewModels.Director;
using MoviesWeb.ViewModels.Movie;
using MoviesWeb.ViewModels.MovieCast;

namespace MoviesWeb.MapperProfiles
{
    public class ViewModelToDomainMapperProfile : Profile
    {
        public ViewModelToDomainMapperProfile()
        {
            CreateMap<MovieCastCreateViewModel, MovieCast>();
            CreateMap<MovieViewModel, Movie>();
            CreateMap<MovieCastViewModel, MovieCast>();
            CreateMap<Movie, MovieViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl)).ReverseMap();
            CreateMap<Movie, EditMovieViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl))
                                                  .ForMember(d => d.ImageId, opt => opt.MapFrom(src => src.Image.Id)).ReverseMap();

            CreateMap<ActorViewModel, Actor>();
            CreateMap<Actor, ActorViewModel>();
            //CreateMap<Actor, ActorViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl)).ReverseMap();
            CreateMap<Actor, EditActorViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl))
                                                  .ForMember(d => d.ImageId, opt => opt.MapFrom(src => src.Image.Id)).ReverseMap();

            CreateMap<DirectorViewModel, Director>();
            CreateMap<Director, DirectorViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl)).ReverseMap();
            CreateMap<Director, EditDirectorViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl))
                                                  .ForMember(d => d.ImageId, opt => opt.MapFrom(src => src.Image.Id)).ReverseMap();

            CreateMap<MovieCast, MovieCastViewModel>().ForMember(d => d.ActorId, opt => opt.MapFrom(src => src.Actor.Id))
                .ForMember(d => d.MovieId, opt => opt.MapFrom(src => src.Movie.Id)).ReverseMap();
            CreateMap<MovieCast, MovieCastCreateViewModel>().ForMember(d => d.ActorId, opt => opt.MapFrom(src => src.Actor.Id))
                .ForMember(d => d.MovieId, opt => opt.MapFrom(src => src.Movie.Id)).
                ForMember(d => d.ActorImageUrl, opt => opt.MapFrom(src => src.Actor.Image.ImageUrl))
                .ForMember(d => d.MovieImageUrl, opt => opt.MapFrom(src => src.Movie.Image.ImageUrl)).ReverseMap();

        }
    }
}
