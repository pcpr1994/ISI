using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeRepository _userTypeRepository;

        public UserTypeController(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllUserType()
        {
            return Ok(await _userTypeRepository.GetAllUserType());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserTypeDetails(int id)
        {
            return Ok(await _userTypeRepository.GetUserTypeDetails(id));
        }

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUserType([FromBody] UserType userType)
        {
            if (userType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userTypeRepository.InsertUserType(userType);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserType([FromBody] UserType userType)
        {
            if (userType == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userTypeRepository.UpdateUserType(userType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalData(int id)
        {
            await _userTypeRepository.DeleteUserType(new UserType { ID = id });

            return NoContent();
        }
    }
}
