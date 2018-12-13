using AutoFixture;
using Belatrix.Models;
using Belatrix.Repository;
using Belatrix.WebApi.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Belatrix.WebApi.Tests
{
    public class ArtistControllerTests
    {
        private ArtistController _artist;
        [SetUp]
        public void Setup()
        {
            _artist = new ArtistController(CreateUnitOfWork());
        }

        [Test]
        public void Get_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _artist.Get() as OkObjectResult;
            var result = (List<Playlist>)request.Value;

            // Assert
            result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Post_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _artist.Post(null) as OkObjectResult;
            var result = (int)request.Value;

            // Assert
            result.Should().BeGreaterThan(0);
        }

        private IUnitofWork CreateUnitOfWork()
        {
            var fixture = new Fixture();
            var artist = fixture.Build<Artist>()
                .Without(a => a.Album)
                .CreateMany<Artist>(100).ToList();

            var artistRepository = new Mock<IArtistRepository>();

            artistRepository.Setup(x => x.Add(It.Is<Artist>(a => a == null))).Returns(0);
            artistRepository.Setup(x => x.Add(It.Is<Artist>(a => a == newArtist()))).Returns(1);
            artistRepository.Setup(x => x.GetList()).Returns(artist);

            var unit = new Mock<IUnitofWork>();
            unit.Setup(x => x.Artists).Returns(artistRepository.Object);
            return unit.Object;
        }

        private Artist newArtist()
        {
            return new Artist
            {
                ArtistId = 1,
                Name = "Bethoveen"
            };
        }
    }
}