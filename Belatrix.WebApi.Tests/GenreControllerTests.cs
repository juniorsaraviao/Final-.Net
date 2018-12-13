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
    public class GenreControllerTests
    {
        private GenreController _genre;
        [SetUp]
        public void Setup()
        {
            _genre = new GenreController(CreateUnitOfWork());
        }

        [Test]
        public void Get_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _genre.Get() as OkObjectResult;
            var result = (List<Genre>)request.Value;

            // Assert
            result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Post_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _genre.Post(null) as OkObjectResult;
            var result = (int)request.Value;

            // Assert
            result.Should().BeGreaterThan(0);
        }

        private IUnitofWork CreateUnitOfWork()
        {
            var fixture = new Fixture();
            var genre = fixture.Build<Genre>()
                .Without(a => a.Track)
                .CreateMany<Genre>(100).ToList();

            var genreRepository = new Mock<IGenreRepository>();

            genreRepository.Setup(x => x.Add(It.Is<Genre>(a => a == null))).Returns(0);
            genreRepository.Setup(x => x.Add(It.Is<Genre>(a => a == newGenre()))).Returns(1);
            genreRepository.Setup(x => x.GetList()).Returns(genre);

            var unit = new Mock<IUnitofWork>();
            unit.Setup(x => x.Genres).Returns(genreRepository.Object);
            return unit.Object;
        }

        private Genre newGenre()
        {
            return new Genre
            {
                GenreId = 1,
                Name = "Rock in spanish"
            };
        }
    }
}