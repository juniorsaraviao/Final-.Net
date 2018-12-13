using Belatrix.Models;
using Belatrix.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IUnitofWork _unit;
        public GenreController(IUnitofWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_unit.Genres.GetById(id));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unit.Genres.GetList());
        }

        [HttpPost]
        public IActionResult Post(Genre genre)
        {
            if (genre == null) return BadRequest();
            return Ok(_unit.Genres.Add(genre));
        }

        [HttpDelete]
        public IActionResult Delete(Genre genre)
        {
            return Ok(_unit.Genres.Delete(genre));
        }

        [HttpPut]
        public IActionResult Update(Genre genre)
        {
            return Ok(_unit.Genres.Update(genre));
        }
    }
}