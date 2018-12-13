using Belatrix.Models;
using Belatrix.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IUnitofWork _unit;
        public ArtistController(IUnitofWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_unit.Artists.GetById(id));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unit.Artists.GetList());
        }

        [HttpPost]
        public IActionResult Post(Artist artist)
        {
            if (artist == null) return BadRequest();
            return Ok(_unit.Artists.Add(artist));
        }

        [HttpDelete]
        public IActionResult Delete(Artist artist)
        {
            return Ok(_unit.Artists.Delete(artist));
        }

        [HttpPut]
        public IActionResult Update(Artist artist)
        {
            return Ok(_unit.Artists.Update(artist));
        }
    }
}
