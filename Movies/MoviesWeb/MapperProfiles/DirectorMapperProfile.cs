using AutoMapper;
using Domain.Entity;
using MoviesWeb.ViewModels.Director;

namespace MoviesWeb.MapperProfiles
{
    public class DirectorMapperProfile : Profile
    {
        public DirectorMapperProfile()
        {
            CreateMap<Director, DirectorViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.DirectorId))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl))
                .ForMember(dest => dest.Photo, opt => opt.Ignore()).ReverseMap();

            CreateMap<Director, EditDirectorViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.DirectorId))
                .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl))
                .ForMember(d => d.Photo, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<EditDirectorViewModel, Director>()
                .ForMember(d => d.DirectorId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => new Image(s.ImageUrl)))
                .ForMember(d => d.MovieDirectors, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedBy, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
