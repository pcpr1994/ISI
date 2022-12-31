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
    public class SpecialUsersController : ControllerBase
    {    
        private readonly ISpecialUsersRepository _specialUsersRepository;

        public SpecialUsersController(ISpecialUsersRepository specialUsersRepository)
        {
            _specialUsersRepository = specialUsersRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllSpecialUser()
        {
            return Ok(await _specialUsersRepository.GetAllSpecialUser());
        }

        [HttpGet("{numero}")]
        public async Task<IActionResult> GetSpecialUserByID(int numero)
        {
            return Ok(await _specialUsersRepository.GetSpecialUserByID(numero));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertSpecialUser([FromBody] SpecialUser specialUser)
        {
            if (specialUser == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _specialUsersRepository.InsertSpecialUser(specialUser);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateSpecialUser([FromBody] SpecialUser specialUser)
        {
            if (specialUser == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _specialUsersRepository.UpdateSpecialUser(specialUser);
            return NoContent();
        }

        [HttpDelete("{numero}")]
        public async Task<IActionResult> DeleteSpecialUser(int numero)
        {
            await _specialUsersRepository.DeleteSpecialUser(new SpecialUser { Id = numero });

            return NoContent();
        }
    }
}
