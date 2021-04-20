using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Features.ActorFeatures.Queries;
using ApplicationCore.Paging;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Moq;
using MoviesWeb.MapperProfiles;
using Xunit;

namespace Movies.Web.Test
{
    public class ActorControllerTest
    {
        private IList<Profile> profiles = new List<Profile>
        {
            new MovieMapperProfile(),
            new ActorMapperProfile(),
            new DirectorMapperProfile(),
            new MovieActorMapperProfile()
        };

        [Fact]
        public async void Verify_GetActorsTest()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfiles(profiles));
            var mapper = mapperConfiguration.CreateMapper();
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            var mockpaginatedActors = new PaginatedList<Actor>(
                new List<Actor>
            {
                new Actor
                {
                    ActorId = 1,
                    Name = "mahesh"
                },
                new Actor
                {
                    ActorId = 2,
                    Name = "allu"
                }
            },2,0,2);

            var paginatedActors = mockMediator.Setup(m =>
              m.Send(It.IsAny<GetPaginatedActorsQuery>(), It.IsAny<CancellationToken>())
            ).Returns(Task.FromResult(mockpaginatedActors));

            var actors = await mockMediator.Object.Send(new GetPaginatedActorsQuery("ma", 1, 2));
            Assert.Equal(actors, mockpaginatedActors);
        }
    }
}
