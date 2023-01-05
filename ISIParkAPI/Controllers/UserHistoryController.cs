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
    public class UserHistoryController : ControllerBase
    {
        private readonly IUserHistoryRepository _userHistoryRepository;

        public UserHistoryController(IUserHistoryRepository userHistoryRepository)
        {
            _userHistoryRepository = userHistoryRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserHistory()
        {
            return Ok(await _userHistoryRepository.GetAllUserHistory());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserHistoryID(int id)
        {
            return Ok(await _userHistoryRepository.GetUserHistoryID(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserHistory([FromBody] UserHistory userHistory)
        {
            if (userHistory == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userHistoryRepository.InsertUserHistory(userHistory);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserHistory([FromBody] UserHistory userHistory)
        {
            if (userHistory == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userHistoryRepository.UpdateUserHistory(userHistory);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserHistory(int id)
        {
            await _userHistoryRepository.DeleteUserHistory(new UserHistory { Utilizadorid = id });

            return NoContent();
        }
    }
}
