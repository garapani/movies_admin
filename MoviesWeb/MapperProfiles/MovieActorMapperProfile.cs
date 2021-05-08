using AutoMapper;
using Domain.Entity;
using MoviesWeb.ViewModels.MovieActor;

namespace MoviesWeb.MapperProfiles
{
    public class MovieActorMapperProfile: Profile
    {
        public MovieActorMapperProfile()
        {
            CreateMap<MovieActor, MovieActorViewModel>().ReverseMap();
            CreateMap<MovieActorCreateViewModel, MovieActor>();
            CreateMap<EditMovieActorViewModel, MovieActor>().ReverseMap();
        }
    }
}
