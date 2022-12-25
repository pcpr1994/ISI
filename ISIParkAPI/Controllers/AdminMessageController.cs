using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminMessageController : ControllerBase
    {
        private readonly IAdminMessageRepository _adminMessageRepository;

        public AdminMessageController(IAdminMessageRepository adminMessageRepository)
        {
            _adminMessageRepository = adminMessageRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllAdminMessage()
        {
            return Ok(await _adminMessageRepository.GetAllAdminMessage());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdminMessageDetails(int id)
        {
            return Ok(await _adminMessageRepository.GetAdminMessageDetails(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertAdminMessageHistory([FromBody] AdminMessage adminMessage)
        {
            if (adminMessage == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _adminMessageRepository.InsertAdminMessage(adminMessage);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateAdminMessage([FromBody] AdminMessage adminMessage)
        {
            if (adminMessage == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _adminMessageRepository.UpdateAdminMessage(adminMessage);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminMessage(int id)
        {
            await _adminMessageRepository.DeleteAdminMessage(new AdminMessage { Id_Mensagem = id });

            return NoContent();
        }
    }
}
