using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAddress()
        {
            return Ok(await _addressRepository.GetAllAddress());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressDetails(int id)
        {
            return Ok(await _addressRepository.GetAddressDetails(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertAddressHistory([FromBody] Address address)
        {
            if (address == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _addressRepository.InsertAddress(address);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAddress([FromBody] Address address)
        {
            if (address == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _addressRepository.UpdateAddress(address);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _addressRepository.DeleteAddress(new Address { ID_Morada = id });

            return NoContent();
        }
    }
}
