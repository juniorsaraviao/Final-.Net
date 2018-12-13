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
    public class AlbumControllerTests
    {
        private AlbumController _album;
        [SetUp]
        public void Setup()
        {
            _album = new AlbumController(CreateUnitOfWork());
        }

        [Test]
        public void Get_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _album.Get() as OkObjectResult;
            var result = (List<Album>)request.Value;

            // Assert
            result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Post_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _album.Post(null) as OkObjectResult;
            var result = (int)request.Value;

            // Assert
            result.Should().BeGreaterThan(0);
        }

        private IUnitofWork CreateUnitOfWork()
        {
            var fixture = new Fixture();
            var album = fixture.Build<Album>()
                .Without(a => a.Track)
                .CreateMany<Album>(100).ToList();

            var albumRepository = new Mock<IAlbumRepository>();

            albumRepository.Setup(x => x.Add(It.Is<Album>(a => a == null))).Returns(0);
            albumRepository.Setup(x => x.Add(It.Is<Album>(a => a == newAlbum()))).Returns(1);
            albumRepository.Setup(x => x.GetList()).Returns(album);

            var unit = new Mock<IUnitofWork>();
            unit.Setup(x => x.Albums).Returns(albumRepository.Object);
            return unit.Object;
        }

        private Album newAlbum()
        {
            return new Album
            {
                AlbumId = 1,
                Title = "New Wave",
                ArtistId = 1
            };
        }
    }
}