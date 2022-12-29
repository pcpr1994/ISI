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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Authorize]
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
        [Route("getAll")]
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
        [Route("insert")]
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
        [Route("update")]
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
