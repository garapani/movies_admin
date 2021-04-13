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
            CreateMap<MovieCastCreateViewModel, MovieActor>();
            CreateMap<MovieViewModel, Movie>();
            CreateMap<MovieCastViewModel, MovieActor>();
            CreateMap<Movie, MovieViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl)).ReverseMap();
            CreateMap<Movie, EditMovieViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl));

            CreateMap<ActorViewModel, Actor>();
            CreateMap<Actor, ActorViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl)).ReverseMap();
            CreateMap<Actor, EditActorViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl));

            CreateMap<DirectorViewModel, Director>();
            CreateMap<Director, DirectorViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl)).ReverseMap();
            CreateMap<Director, EditDirectorViewModel>().ForMember(d => d.ImageUrl, opt => opt.MapFrom(src => src.Image.ImageUrl));

            CreateMap<MovieActor, MovieCastViewModel>().ForMember(d => d.ActorId, opt => opt.MapFrom(src => src.Actor.ActorId))
                .ForMember(d => d.MovieId, opt => opt.MapFrom(src => src.Movie.MovieId)).ReverseMap();
            CreateMap<MovieActor, MovieCastCreateViewModel>().ForMember(d => d.ActorId, opt => opt.MapFrom(src => src.Actor.ActorId))
                .ForMember(d => d.MovieId, opt => opt.MapFrom(src => src.Movie.MovieId)).
                ForMember(d => d.ActorImageUrl, opt => opt.MapFrom(src => src.Actor.Image.ImageUrl))
                .ForMember(d => d.MovieImageUrl, opt => opt.MapFrom(src => src.Movie.Image.ImageUrl)).ReverseMap();

        }
    }
}
