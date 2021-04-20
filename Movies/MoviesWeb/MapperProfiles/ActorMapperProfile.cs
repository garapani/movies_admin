using System.Collections.Generic;
using ApplicationCore.Paging;
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
                .ForMember(dest => dest.Photo, opt => opt.Ignore()).ReverseMap();

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

            CreateMap<Actor[], IEnumerable<ActorViewModel>>();
            CreateMap<List<Actor>, List<ActorViewModel>>();
            CreateMap<PaginatedList<Actor>, PaginatedList<ActorViewModel>>();
        }
    }
}
