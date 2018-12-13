using Belatrix.Models;
using Belatrix.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/media")]
    [ApiController]
    public class MediaTypeController : ControllerBase
    {
        private readonly IUnitofWork _unit;
        public MediaTypeController(IUnitofWork unit)
        {
            _unit = unit;
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_unit.Medias.GetById(id));
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unit.Medias.GetList());
        }

        [HttpPost]
        public IActionResult Post(MediaType media)
        {
            if (media == null) return BadRequest();
            return Ok(_unit.Medias.Add(media));
        }

        [HttpDelete]
        public IActionResult Delete(MediaType media)
        {
            return Ok(_unit.Medias.Delete(media));
        }

        [HttpPut]
        public IActionResult Update(MediaType media)
        {
            return Ok(_unit.Medias.Update(media));
        }
    }
}
