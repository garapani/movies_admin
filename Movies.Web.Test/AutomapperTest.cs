using ApplicationCore.Common.Models;
using AutoMapper;
using Domain.Entity;
using FizzWare.NBuilder;
using MoviesWeb.MapperProfiles;
using MoviesWeb.ViewModels.Actor;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Movies.Web.Test
{
    public class AutomapperTest
    {
        private IList<Profile> profiles = new List<Profile>
        {
            new MovieMapperProfile(),
            new ActorMapperProfile(),
            new DirectorMapperProfile(),
            new MovieActorMapperProfile()
        };

        [Fact]
        public void Verify_AutoMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            cfg.CreateMap<Actor, ActorViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.ActorId))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(s => s.Image.ImageUrl))
            .ForMember(dest => dest.Photo, opt => opt.Ignore()));
           
            configuration.AssertConfigurationIsValid();

            var source = new Actor
            {
                ActorId = 2,
                Name = "test"
            };
            AutoMapper.Mapper mapper = new Mapper(configuration);
            var result = mapper.Map<Actor, ActorViewModel>(source);
            Assert.Equal(2, result.Id);
            Assert.Equal("test", result.Name);
        }

        [Fact]
        public void Verify_AllProfiles()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));
            configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void Verify_PaginatedList()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));
            Mapper mapper = new Mapper(configuration);
            var actor = Builder<Actor>.CreateNew().Build();
            actor.Image = new Image("temp");
            var actorViewModel = mapper.Map<Actor, ActorViewModel>(actor);
            var list = Builder<Actor>.CreateListOfSize(10).Build().ToList();           
            var temp1 = mapper.Map<List<Actor>, List<ActorViewModel>>(list);
            var temp2 = new PaginatedList<Actor>(list.ToList(), 10, 1, 2);
            var viewModels = mapper.Map<PaginatedList<Actor>, PaginatedList<ActorViewModel>>(temp2);
        }
    }
}
