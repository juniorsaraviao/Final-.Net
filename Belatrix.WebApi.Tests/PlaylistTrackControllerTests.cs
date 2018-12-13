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
    public class PlaylistTrackControllerTests
    {
        private PlaylistTrackController _playlistTrack;
        [SetUp]
        public void Setup()
        {
            _playlistTrack = new PlaylistTrackController(CreateUnitOfWork());
        }

        [Test]
        public void Get_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _playlistTrack.Get() as OkObjectResult;
            var result = (List<PlaylistTrack>)request.Value;

            // Assert
            result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Post_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _playlistTrack.Post(null) as OkObjectResult;
            var result = (int)request.Value;

            // Assert
            result.Should().BeGreaterThan(0);
        }

        private IUnitofWork CreateUnitOfWork()
        {
            var fixture = new Fixture();
            var playlistTrack = fixture.Build<PlaylistTrack>()
                .CreateMany<PlaylistTrack>(100).ToList();

            var playlistTrackRepository = new Mock<IPlaylistTrackRepository>();

            playlistTrackRepository.Setup(x => x.Add(It.Is<PlaylistTrack>(a => a == null))).Returns(0);
            playlistTrackRepository.Setup(x => x.Add(It.Is<PlaylistTrack>(a => a == newPlaylistTrack()))).Returns(1);
            playlistTrackRepository.Setup(x => x.GetList()).Returns(playlistTrack);

            var unit = new Mock<IUnitofWork>();
            unit.Setup(x => x.PlaylistTracks).Returns(playlistTrackRepository.Object);
            return unit.Object;
        }

        private PlaylistTrack newPlaylistTrack()
        {
            return new PlaylistTrack
            {
                PlaylistId = 1,
                TrackId=2
            };
        }
    }
}