using ISIParkAPIMySQL.Data.Repositories;
using ISIParkAPIMySQL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ISIParkAPIMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDataController : ControllerBase
    {
        private readonly IPersonalDataRepository _personalDataRepository;

        public PersonalDataController(IPersonalDataRepository personalDataRepository)
        {
            _personalDataRepository = personalDataRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonalData()
        {
            return Ok(await _personalDataRepository.GetAllPersonalData());
        }

        [HttpGet("{numero}")]
        public async Task<IActionResult> GetPersonalDataDetails(int numero)
        {
            return Ok(await _personalDataRepository.GetPersonalDataDetails(numero));
        }

        [HttpPost]
        public async Task<IActionResult> InsertPersonalData([FromBody] PersonalData personalData)
        {
            if (personalData == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _personalDataRepository.InsertPersonalData(personalData);
            return Created("created", inserted);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonalData([FromBody] PersonalData personalData)
        {
            if (personalData == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _personalDataRepository.UpdatePersonalData(personalData);
            return NoContent();
        }

        [HttpDelete("{numero}")]
        public async Task<IActionResult> DeletePersonalData(int numero)
        {
            await _personalDataRepository.DeletePersonalData(new PersonalData { Numero = numero });

            return NoContent();
        }
    }
}
