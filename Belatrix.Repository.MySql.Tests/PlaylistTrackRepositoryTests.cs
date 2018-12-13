using Belatrix.Models;
using Belatrix.Repository.MySql;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace TBelatrix.Repository.MySql.Tests
{
    public class PlaylistTrackRepositoryTests
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
            var playlistTrack = new PlaylistTrack
            {
                PlaylistId=20,
                TrackId = 5
            };

            //Act
            var result = _unit.PlaylistTracks.Add(playlistTrack);

            //Assert
            result.Should().BeGreaterThan(0);

        }

        [Test]
        public void Delete_PlaylistTrack()
        {
            //Arrange
            var playlistTrack = new PlaylistTrack
            {
                TrackId=2
            };

            //Act
            var other = _unit.PlaylistTracks.Add(playlistTrack);
            var result = _unit.PlaylistTracks.Delete(playlistTrack);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Update_Playlist()
        {
            //Arrange
            var playlistTrack = _unit.PlaylistTracks.GetById(5);
            playlistTrack.PlaylistId = 17;

            //Act

            var result = _unit.PlaylistTracks.Update(playlistTrack);

            //Assert
            result.Should().BeTrue();

        }

        [Test]
        public void Get_PlaylistTrack()
        {
            //Arrange


            //Act

            var result = _unit.PlaylistTracks.GetList();

            //Assert
            result.Should().HaveCountGreaterThan(1);

        }

        [Test]
        public void Get_PlaylistTrack_ById()
        {
            //Arrange


            //Act

            var result = _unit.PlaylistTracks.GetById(4);

            //Assert
            result.PlaylistId.Should().Be(8);

        }
    }
}