using AutoMapper;
using Domain.Entity;
using MoviesWeb.ViewModels.MovieDirector;

namespace MoviesWeb.MapperProfiles
{
    public class MovieDirectorMapperProfile : Profile
    {
        public MovieDirectorMapperProfile()
        {
            CreateMap<MovieDirector, MovieDirectorViewModel>().ReverseMap();
            CreateMap<MovieDirectorCreateViewModel, MovieDirector>();
        }
    }
}
