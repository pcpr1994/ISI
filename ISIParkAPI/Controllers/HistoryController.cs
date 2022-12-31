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
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryController(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllHistory()
        {
            return Ok(await _historyRepository.GetAllHistory());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonalDataDetails(int id)
        {
            return Ok(await _historyRepository.GetHistoryDetails(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertHistory([FromBody] History history)
        {
            if (history == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _historyRepository.InsertHistory(history);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateHistory([FromBody] History history)
        {
            if (history == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _historyRepository.UpdateHistory(history);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalData(int id)
        {
            await _historyRepository.DeleteHistory(new History { ID = id });

            return NoContent();
        }
    }
}