using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;

        public VehicleTypeController(IVehicleTypeRepository vehicleTypeRepository)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllVehickeType()
        {
            return Ok(await _vehicleTypeRepository.GetAllVehicleType());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleTypeDetails(int id)
        {
            return Ok(await _vehicleTypeRepository.GetVehicleTypeDetails(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertVehicleType([FromBody] VehicleType vehicleType)
        {
            if (vehicleType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _vehicleTypeRepository.InsertVehicleType(vehicleType);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateVehicletType([FromBody] VehicleType vehicleType)
        {
            if (vehicleType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _vehicleTypeRepository.UpdateVehicleType(vehicleType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleType(int id)
        {
            await _vehicleTypeRepository.DeleteVehicleType(new VehicleType { ID_Veiculo = id });

            return NoContent();
        }
    }
}
