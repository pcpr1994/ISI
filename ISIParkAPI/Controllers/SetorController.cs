using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISectorRepository _sectorRepository;

        public SetorController(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllSector()
        {
            return Ok(await _sectorRepository.GetAllSector());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSectorDetails(int id)
        {
            return Ok(await _sectorRepository.GetSectorDetails(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertSector([FromBody] Sector sector)
        {
            if (sector == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _sectorRepository.InsertSector(sector);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateSector([FromBody] Sector sector)
        {
            if (sector == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _sectorRepository.UpdateSector(sector);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSector(int id)
        {
            await _sectorRepository.DeleteSector(new Sector { ID_Setor = id });

            return NoContent();
        }
    }
}
