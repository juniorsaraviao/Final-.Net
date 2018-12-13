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
    public class MediaTypeControllerTests
    {
        private MediaTypeController _media;
        [SetUp]
        public void Setup()
        {
            _media = new MediaTypeController(CreateUnitOfWork());
        }

        [Test]
        public void Get_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _media.Get() as OkObjectResult;
            var result = (List<MediaType>)request.Value;

            // Assert
            result.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void Post_GoodData_OkResult()
        {
            // Arrange            

            // Act
            var request = _media.Post(null) as OkObjectResult;
            var result = (int)request.Value;

            // Assert
            result.Should().BeGreaterThan(0);
        }

        private IUnitofWork CreateUnitOfWork()
        {
            var fixture = new Fixture();
            var media = fixture.Build<MediaType>()
                .Without(a => a.Track)
                .CreateMany<MediaType>(100).ToList();

            var mediatypeRepository = new Mock<IMediaTypeRepository>();

            mediatypeRepository.Setup(x => x.Add(It.Is<MediaType>(a => a == null))).Returns(0);
            mediatypeRepository.Setup(x => x.Add(It.Is<MediaType>(a => a == newMediaType()))).Returns(1);
            mediatypeRepository.Setup(x => x.GetList()).Returns(media);

            var unit = new Mock<IUnitofWork>();
            unit.Setup(x => x.Medias).Returns(mediatypeRepository.Object);
            return unit.Object;
        }

        private MediaType newMediaType()
        {
            return new MediaType
            {
                MediaTypeId = 1,
                Name = "LP"
            };
        }
    }
}