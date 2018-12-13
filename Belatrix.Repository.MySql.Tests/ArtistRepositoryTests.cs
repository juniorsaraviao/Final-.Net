using Belatrix.Models;
using Belatrix.Repository.MySql;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TBelatrix.Repository.MySql.Tests
{
    public class ArtistRepositoryTests
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
            var artist = new Artist
            {
                Name = "Gustavo Cerati"
            };

            //Act
            var result = _unit.Artists.Add(artist);

            //Assert
            result.Should().BeGreaterThan(0);

        }

        [Test]
        public void Delete_Artist()
        {
            //Arrange
            var artist = new Artist
            {
                Name = "Bon Jove"
            };

            //Act
            var other = _unit.Artists.Add(artist);
            var result = _unit.Artists.Delete(artist);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Update_Aritst()
        {
            //Arrange
            var artist = _unit.Artists.GetById(5);
            artist.Name = "Pedro Suarez Vertiz";

            //Act

            var result = _unit.Artists.Update(artist);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Get_Artist()
        {
            //Arrange


            //Act

            var result = _unit.Artists.GetList();

            //Assert
            result.Should().HaveCountGreaterThan(1);

        }

        [Test]
        public void Get_Artist_ById()
        {
            //Arrange


            //Act

            var result = _unit.Artists.GetById(3);

            //Assert
            result.Name.Should().Be("Aerosmith");

        }
    }
}