using AutoMapper;
using Domain.Entity;
using MoviesWeb.ViewModels.Actor;

namespace MoviesWeb.MapperProfiles
{
    public class ActorMapperProfile : Profile
    {
        public ActorMapperProfile()
        {
            AllowNullCollections = true;
            CreateMap<Actor, ActorViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.ActorId))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl))
                .ForMember(dest => dest.Photo, opt => opt.Ignore())
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(s => s.MovieActors)).ReverseMap();

            CreateMap<ActorViewModel, Actor>()
                .ForMember(d => d.ActorId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => new Image(s.ImageUrl)))
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => new Gender(s.Gender)))
                .ForMember(d => d.MovieActors, opt => opt.Ignore());

            CreateMap<Actor, EditActorViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.ActorId))
                .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl))
                .ForMember(dest => dest.Photo, opt => opt.Ignore()).ReverseMap();

            CreateMap<EditActorViewModel, Actor>()
                 .ForMember(d => d.ActorId, opt => opt.MapFrom(s => s.Id))
                 .ForMember(d => d.Image, opt => opt.MapFrom(s => new Image(s.ImageUrl)))
                 .ForMember(d => d.Gender, opt => opt.MapFrom(s => new Gender(s.Gender)))
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.LastModifiedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore())
                 .ForMember(dest => dest.MovieActors, opt => opt.Ignore());

            //CreateMap(typeof(PaginatedList<>), typeof(PaginationInfoViewModel<>));
            
            //CreateMap<PaginatedList<Actor>, PaginatedList<ActorViewModel>>()
            //    .ForMember(d => d.Capacity, opt => opt.MapFrom(s => s.Capacity))
            //    .ForMember(d => d.Count, opt => opt.MapFrom(s => s.Count))
            //    .ForMember(d => d.HasNextPage, opt => opt.MapFrom(s => s.HasNextPage))
            //    .ForMember(d => d.HasPreviousPage, opt => opt.MapFrom(s => s.HasPreviousPage))
            //    .ForMember(d => d.ItemsPerPage, opt => opt.MapFrom(s => s.ItemsPerPage))
            //    .ForMember(d => d.PageIndex, opt => opt.MapFrom(s => s.PageIndex))
            //    .ForMember(d => d.TotalPages, opt => opt.MapFrom(s => s.TotalPages))
            //    .AfterMap((s, d) => CreateMap(IEnumerable<Actor>, IEnumerable<ActorViewModel>)();
        }
    }
}
