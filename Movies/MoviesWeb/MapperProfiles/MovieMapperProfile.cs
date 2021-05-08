using ApplicationCore.Common.Models;
using AutoMapper;
using Domain.Entity;
using MoviesWeb.ViewModels.Movie;

namespace MoviesWeb.MapperProfiles
{
    public class MovieMapperProfile : Profile
    {
        public MovieMapperProfile()
        {
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.MovieId))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(s => s.Video.VideoUrl))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(s => s.Language.Name))
                .ForMember(dest => dest.Photo, opt => opt.Ignore());

            CreateMap<MovieViewModel, Movie>()
                .ForMember(d => d.MovieId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => new Image(s.ImageUrl)))
                .ForMember(d => d.MovieCrew, opt => opt.Ignore())
                .ForMember(d => d.MovieDirectors, opt => opt.Ignore())
                .ForMember(d => d.Video, opt => opt.MapFrom(s => new Video(s.VideoUrl)))
                .ForMember(d => d.Keywords, opt => opt.Ignore())
                .ForMember(d => d.Language, opt => opt.MapFrom(s => new Language(s.Language)))
                .ForMember(d => d.Popularity, opt => opt.Ignore())
                .ForMember(d => d.Tagline, opt => opt.Ignore())
                .ForMember(d => d.ViewCount, opt => opt.Ignore())
                .ForMember(d => d.Genres, opt => opt.Ignore());

            CreateMap<Movie, EditMovieViewModel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.MovieId))
                .ForMember(d => d.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl))
                .ForMember(dest => dest.VideoUrl, opt => opt.MapFrom(s => s.Video.VideoUrl))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(s => s.Language.Name))
                .ForMember(dest => dest.Photo, opt => opt.Ignore());

            CreateMap<EditMovieViewModel, Movie>()
                .ForMember(d => d.MovieId, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Image, opt => opt.MapFrom(s => new Image(s.ImageUrl)))
                .ForMember(d => d.MovieCrew, opt => opt.Ignore())
                .ForMember(d => d.MovieDirectors, opt => opt.Ignore())
                .ForMember(d => d.Video, opt => opt.MapFrom(s => new Video(s.VideoUrl)))
                .ForMember(d => d.Keywords, opt => opt.Ignore())
                .ForMember(d => d.Language, opt => opt.MapFrom(s => new Language(s.Language)))
                .ForMember(d => d.Popularity, opt => opt.Ignore())
                .ForMember(d => d.Tagline, opt => opt.Ignore())
                .ForMember(d => d.ViewCount, opt => opt.Ignore())
                .ForMember(d => d.Genres, opt => opt.Ignore())
                .ForMember(d => d.CreatedAt, opt => opt.Ignore())
                .ForMember(d => d.CreatedBy, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedAt, opt => opt.Ignore())
                .ForMember(d => d.LastModifiedBy, opt => opt.Ignore())
                .ForMember(d => d.MovieActors, opt => opt.Ignore());

            CreateMap<PaginatedList<Movie>, PaginatedList<MovieViewModel>>();
        }
    }
}
