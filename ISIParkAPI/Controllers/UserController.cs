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
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await _userRepository.GetAllUser());
        }

        [HttpGet("{numero}")]
        public async Task<IActionResult> GetUserById(int numero)
        {
            return Ok(await _userRepository.GetUserById(numero));
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO user)
        {
            if (user == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userRepository.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{numero}")]
        public async Task<IActionResult> DeleteUser(int numero)
        {
            await _userRepository.DeleteUser(new UserDTO { Id = numero });

            return NoContent();
        }
    }
}
