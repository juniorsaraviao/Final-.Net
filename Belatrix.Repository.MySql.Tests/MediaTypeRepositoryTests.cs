using Belatrix.Models;
using Belatrix.Repository.MySql;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TBelatrix.Repository.MySql.Tests
{
    public class MediaTypeRepositoryTests
    {
        private UnitofWork _unit;
        [SetUp]
        public void Setup()
        {
            _unit = new UnitofWork(new ChinookContext(new DbContextOptionsBuilder<ChinookContext>().UseMySQL<ChinookContext>("server=localhost;port=3306;userid=root;password=root;database=chinook;").Options));
        }

        [Test]
        public void Insert_GoodData_Return_One()
        {
            //Arrange
            var media = new MediaType
            {
                Name = "LP"
            };

            //Act
            var result = _unit.Medias.Add(media);

            //Assert
            result.Should().BeGreaterThan(0);

        }

        [Test]
        public void Delete_Media()
        {
            //Arrange
            var media = new MediaType
            {
                Name = "Cassette"
            };

            //Act
            var other = _unit.Medias.Add(media);
            var result = _unit.Medias.Delete(media);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Update_Media()
        {
            //Arrange
            var media = _unit.Medias.GetById(5);
            media.Name = "Grabadora";

            //Act

            var result = _unit.Medias.Update(media);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Get_Media()
        {
            //Arrange


            //Act

            var result = _unit.Medias.GetList();

            //Assert
            result.Should().HaveCountGreaterThan(1);

        }

        [Test]
        public void Get_Media_ById()
        {
            //Arrange


            //Act

            var result = _unit.Medias.GetById(3);

            //Assert
            result.Name.Should().Be("Protected MPEG-4 video file");

        }
    }
}