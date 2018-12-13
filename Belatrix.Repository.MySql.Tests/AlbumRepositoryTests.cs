using Belatrix.Models;
using Belatrix.Repository.MySql;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TBelatrix.Repository.MySql.Tests
{
    public class AlbumRepositoryTests
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
            var album = new Album
            {
                Title = "These Days",
                ArtistId = 4
            };

            //Act
            var result = _unit.Albums.Add(album);

            //Assert
            result.Should().BeGreaterThan(0);

        }

        [Test]
        public void Delete_Album()
        {
            //Arrange
            var album = new Album
            {
                Title = "Rayando el sol",
                ArtistId = 6,
            };

            //Act
            var other = _unit.Albums.Add(album);
            var result = _unit.Albums.Delete(album);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Update_Album()
        {
            //Arrange
            var album = _unit.Albums.GetById(5);
            album.Title = "Great success";

            //Act

            var result = _unit.Albums.Update(album);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Get_Album()
        {
            //Arrange


            //Act

            var result = _unit.Albums.GetList();

            //Assert
            result.Should().HaveCountGreaterThan(1);

        }

        [Test]
        public void Get_Album_ById()
        {
            //Arrange


            //Act

            var result = _unit.Albums.GetById(3);

            //Assert
            result.Title.Should().Be("Restless and Wild");

        }
    }
}