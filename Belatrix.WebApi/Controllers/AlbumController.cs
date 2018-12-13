using Belatrix.Models;
using Belatrix.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/album")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IUnitofWork _unit;
        public AlbumController(IUnitofWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_unit.Albums.GetById(id));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unit.Albums.GetList());
        }

        [HttpPost]
        public IActionResult Post(Album album)
        {
            if (album == null) return BadRequest();
            return Ok(_unit.Albums.Add(album));
        }

        [HttpDelete]
        public IActionResult Delete(Album album)
        {
            return Ok(_unit.Albums.Delete(album));
        }

        [HttpPut]
        public IActionResult Update(Album album)
        {
            return Ok(_unit.Albums.Update(album));
        }
    }
}