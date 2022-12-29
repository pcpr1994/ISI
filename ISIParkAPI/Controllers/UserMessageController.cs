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
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageRepository _userMessageRepository;

        public UserMessageController(IUserMessageRepository userMessageRepository)
        {
            _userMessageRepository = userMessageRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserMessage()
        {
            return Ok(await _userMessageRepository.GetAllUserMessage());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserMessageID(int id)
        {
            return Ok(await _userMessageRepository.GetUserMessageID(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserMessage([FromBody] UserMessage userMessage)
        {
            if (userMessage == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userMessageRepository.InsertUserMessage(userMessage);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserMessage([FromBody] UserMessage userMessage)
        {
            if (userMessage == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userMessageRepository.UpdateUserMessage(userMessage);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMessage(int id)
        {
            await _userMessageRepository.DeleteUserMessage(new UserMessage { Utilizadorid = id });

            return NoContent();
        }





    }
}
