using ApplicationCore.Paging;
using AutoMapper;
using Domain.Entity;
using MoviesWeb.ViewModels.Crew;

namespace MoviesWeb.MapperProfiles
{
    public class CrewMapperProfile : Profile
    {
        public CrewMapperProfile()
        {
            CreateMap<Crew, CrewViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CrewId))
                .ForMember(d=> d.ImageUrl, opt=> opt.MapFrom(s => s.Image.ImageUrl))
                .ForMember(dest => dest.Photo, opt => opt.Ignore()).ReverseMap();

            CreateMap<CrewViewModel, Crew>()
                .ForMember(d => d.CrewId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => new Image(s.ImageUrl)));

            CreateMap<Crew, EditCrewViewModel>()
               .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CrewId))
               .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl)).ReverseMap();

            CreateMap<EditCrewViewModel, Crew>()
                .ForMember(d => d.CrewId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => new Image(s.ImageUrl)));

            CreateMap<PaginatedList<Crew>, PaginatedList<CrewViewModel>>();
        }
    }
}
