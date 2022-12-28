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
    public class UserContactTypeController : ControllerBase
    {
        private readonly IUserContactTypeRepository _userContactTypeRepository;

        public UserContactTypeController(IUserContactTypeRepository userContactTypeRepository)
        {
            _userContactTypeRepository = userContactTypeRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserContactType()
        {
            return Ok(await _userContactTypeRepository.GetAllUserContactType());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserContactTypeID(int utilizadorid)
        {
            return Ok(await _userContactTypeRepository.GetUserContactTypeID(utilizadorid));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserContactType([FromBody] UserContactType userContactType)
        {
            if (userContactType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userContactTypeRepository.InsertUserContactType(userContactType);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserContactType([FromBody] UserContactType userContactType)
        {
            if (userContactType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userContactTypeRepository.UpdateUserContactType(userContactType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserContactType(int id)
        {
            await _userContactTypeRepository.DeleteUserContactType(new UserContactType { Utilizadorid = id });

            return NoContent();
        }


    }
}
