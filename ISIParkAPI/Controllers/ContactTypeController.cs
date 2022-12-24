using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeController : ControllerBase
    {
        private readonly IContactTypeRepository _contactTypeRepository;

        public ContactTypeController(IContactTypeRepository contactTypeRepository)
        {
            _contactTypeRepository = contactTypeRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllContactType()
        {
            return Ok(await _contactTypeRepository.GetAllContactType());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactTypeDetails(int id)
        {
            return Ok(await _contactTypeRepository.GetContactTypeDetails(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertContactType([FromBody] ContactType contactType)
        {
            if (contactType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _contactTypeRepository.InsertContactType(contactType);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateContactType([FromBody] ContactType contactType)
        {
            if (contactType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _contactTypeRepository.UpdateContactType(contactType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactType(int id)
        {
            await _contactTypeRepository.DeleteContactType(new ContactType { ID = id });

            return NoContent();
        }
    }
}
