using Belatrix.Models;
using Belatrix.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/playlisttrack")]
    [ApiController]
    public class PlaylistTrackController : ControllerBase
    {
        private readonly IUnitofWork _unit;
        public PlaylistTrackController(IUnitofWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_unit.PlaylistTracks.GetById(id));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unit.PlaylistTracks.GetList());
        }

        [HttpPost]
        public IActionResult Post(PlaylistTrack playlistTrack)
        {
            if (playlistTrack == null) return BadRequest();
            return Ok(_unit.PlaylistTracks.Add(playlistTrack));
        }

        [HttpDelete]
        public IActionResult Delete(PlaylistTrack playlistTrack)
        {
            return Ok(_unit.PlaylistTracks.Delete(playlistTrack));
        }

        [HttpPut]
        public IActionResult Update(PlaylistTrack playlistTrack)
        {
            return Ok(_unit.PlaylistTracks.Update(playlistTrack));
        }
    }
}