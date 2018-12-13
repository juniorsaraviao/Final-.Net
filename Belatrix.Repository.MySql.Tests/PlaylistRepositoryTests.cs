using Belatrix.Models;
using Belatrix.Repository.MySql;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TBelatrix.Repository.MySql.Tests
{
    public class PlaylistRepositoryTests
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
            var playlist = new Playlist
            {
                Name = "Rock-español-1"
            };

            //Act
            var result = _unit.Playlists.Add(playlist);

            //Assert
            result.Should().BeGreaterThan(0);

         }

        [Test]
        public void Delete_Playlist()
        {
            //Arrange
            var playlist = new Playlist
            {
                Name = "rockeando"
            };

            //Act
            var other = _unit.Playlists.Add(playlist);
            var result = _unit.Playlists.Delete(playlist);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Update_Playlist()
        {
            //Arrange
            var playlist = _unit.Playlists.GetById(22);
            playlist.Name = "electronica";

            //Act

            var result = _unit.Playlists.Update(playlist);

            //Assert
            result.Should().BeTrue();
                                    
        }

        [Test]
        public void Get_Playlist()
        {
            //Arrange


            //Act

            var result = _unit.Playlists.GetList();

            //Assert
            result.Should().HaveCountGreaterThan(1);

        }

        [Test]
        public void Get_Playlist_ById()
        {
            //Arrange


            //Act

            var result = _unit.Playlists.GetById(4);

            //Assert
            result.Name.Should().Be("Audiobooks");

        }
    }
}