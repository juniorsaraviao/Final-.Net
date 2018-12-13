using Belatrix.Models;
using Belatrix.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/playlist")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IUnitofWork _unit;
        public PlaylistController(IUnitofWork unit)
        {
            _unit = unit;
        }
        [HttpGet]
        [Route ("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_unit.Playlists.GetById(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unit.Playlists.GetList());
        }

        [HttpPost]
        public IActionResult Post(Playlist playlist)
        {
            if (playlist == null) return BadRequest();
            return Ok(_unit.Playlists.Add(playlist));
        }

        [HttpDelete]
        public IActionResult Delete(Playlist playlist)
        {
            return Ok(_unit.Playlists.Delete(playlist));
        }

        [HttpPut]
        public IActionResult Update(Playlist playlist)
        {
            return Ok(_unit.Playlists.Update(playlist));
        }
    }
}