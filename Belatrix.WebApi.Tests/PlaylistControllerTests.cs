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
    public class PlaylistControllerTests
    {
        private PlaylistController _playlist;
        [SetUp]
        public void Setup()
        {
            _playlist = new PlaylistController(CreateUnitOfWork());
        }

        [Test]
        public void Get_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _playlist.Get() as OkObjectResult;
            var result = (List<Playlist>)request.Value;

            // Assert
            result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Post_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _playlist.Post(null) as OkObjectResult;
            var result = (int)request.Value;

            // Assert
            result.Should().BeGreaterThan(0);
        }

        private IUnitofWork CreateUnitOfWork()
        {
            var fixture = new Fixture();
            var playlist = fixture.Build<Playlist>()
                .Without(a => a.PlaylistTrack)
                .CreateMany<Playlist>(100).ToList();

            var playlistRepository = new Mock<IPlaylistRepository>();
            
            playlistRepository.Setup(x => x.Add(It.Is<Playlist>(a => a == null))).Returns(0);
            playlistRepository.Setup(x => x.Add(It.Is<Playlist>(a=>a==newPlaylist()))).Returns(1);
            playlistRepository.Setup(x => x.GetList()).Returns(playlist);

            var unit = new Mock<IUnitofWork>();
            unit.Setup(x => x.Playlists).Returns(playlistRepository.Object);
            return unit.Object;
        }

        private Playlist newPlaylist()
        {
            return new Playlist
            {
                PlaylistId = 1,
                Name = "Chicha"
            };
        }
    }
}