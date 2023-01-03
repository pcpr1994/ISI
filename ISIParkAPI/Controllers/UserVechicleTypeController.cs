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
    public class UserVechicleTypeController : ControllerBase
    {
       private readonly IUserVechicleTypeRepository _userVechicleTypeRepository;

        public UserVechicleTypeController(IUserVechicleTypeRepository userVechicleTypeRepository)
        {
            _userVechicleTypeRepository = userVechicleTypeRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserVechicleTypey()
        {
            return Ok(await _userVechicleTypeRepository.GetAllUserVechicleTypey());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserVechicleTypeID(int id)
        {
            return Ok(await _userVechicleTypeRepository.GetUserVechicleTypeID(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserVechicleType([FromBody] UserVechicleType userVechicleType)
        {
            if (userVechicleType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userVechicleTypeRepository.InsertUserVechicleType(userVechicleType);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserVechicleType([FromBody] UserVechicleType userVechicleType)
        {
            if (userVechicleType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userVechicleTypeRepository.UpdateUserVechicleType(userVechicleType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserVechicleType(int id)
        {
            await _userVechicleTypeRepository.DeleteUserVechicleType(new UserVechicleType { Utilizadorid = id });

            return NoContent();
        }

    }
}
