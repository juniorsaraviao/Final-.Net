using Belatrix.Models;
using Belatrix.Repository.MySql;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TBelatrix.Repository.MySql.Tests
{
    public class GenreRepositoryTests
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
            var genre = new Genre
            {
                Name = "Rock in spanish"
            };

            //Act
            var result = _unit.Genres.Add(genre);

            //Assert
            result.Should().BeGreaterThan(0);

        }

        [Test]
        public void Delete_Genre()
        {
            //Arrange
            var genre = new Genre
            {
                Name = "Chicha peruana"
            };

            //Act
            var other = _unit.Genres.Add(genre);
            var result = _unit.Genres.Delete(genre);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Update_Genres()
        {
            //Arrange
            var genre = _unit.Genres.GetById(5);
            genre.Name = "Electro-pop";

            //Act

            var result = _unit.Genres.Update(genre);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Get_Genre()
        {
            //Arrange


            //Act

            var result = _unit.Genres.GetList();

            //Assert
            result.Should().HaveCountGreaterThan(1);

        }

        [Test]
        public void Get_Genre_ById()
        {
            //Arrange


            //Act

            var result = _unit.Genres.GetById(3);

            //Assert
            result.Name.Should().Be("Metal");

        }
    }
}