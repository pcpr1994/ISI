/*
 * Grupo 4
 * Trabalho II de ISI
 * Alunos
 *  Carlos Pereira nº6498
 *  Paula Rodrigues nº21133
 *  Sérgio Gonçalves nº20343
 *  
 */
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllPlace()
        {
            return Ok(await _placeRepository.GetAllPlace());
        }

        [HttpGet("{numero}")]
        public async Task<IActionResult> GetPlaceById(int numero)
        {
            return Ok(await _placeRepository.GetPlaceById(numero));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertPlace([FromBody] Place place)
        {
            if (place == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _placeRepository.InsertPlace(place);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdatePlace([FromBody] Place place)
        {
            if (place == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _placeRepository.UpdatePlace(place);
            return NoContent();
        }

        [HttpDelete("{numero}")]
        public async Task<IActionResult> DeletePlace(int numero)
        {
            await _placeRepository.DeletePlace(new Place { Numero_lugar = numero });

            return NoContent();
        }
    }
}
