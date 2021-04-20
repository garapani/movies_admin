using ApplicationCore.Paging;
using AutoMapper;
using Domain.Entity;
using MoviesWeb.ViewModels.MovieCrew;

namespace MoviesWeb.MapperProfiles
{
    public class MovieCrewMapperProfile : Profile
    {
        public MovieCrewMapperProfile()
        {
            CreateMap<MovieCrew, MovieCrewViewModel>();
            CreateMap<MovieCrewViewModel, MovieCrew>();
            CreateMap<PaginatedList<MovieCrew>, PaginatedList<MovieCrewViewModel>>();
        }
    }
}
