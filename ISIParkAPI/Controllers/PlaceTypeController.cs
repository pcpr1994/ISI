using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceTypeController : ControllerBase
    {
        private readonly IPlaceTypeRepository _placeTypeRepository;

        public PlaceTypeController(IPlaceTypeRepository placeTypeRepository)
        {
            _placeTypeRepository = placeTypeRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllPlaceType()
        {
            return Ok(await _placeTypeRepository.GetAllPlaceType());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaceTypeDetails(int id)
        {
            return Ok(await _placeTypeRepository.GetPlaceTypeDetails(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertPlaceType([FromBody] PlaceType placeType)
        {
            if (placeType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _placeTypeRepository.InsertPlaceType(placeType);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePlaceType([FromBody] PlaceType placeType)
        {
            if (placeType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _placeTypeRepository.UpdatePlaceType(placeType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaceType(int id)
        {
            await _placeTypeRepository.DeletePlaceType(new PlaceType { N_Tipo = id });

            return NoContent();
        }
    }
}
