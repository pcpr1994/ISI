﻿using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
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

        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> InsertUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inserted = await _userRepository.InsertUser(user);
            return Created("created", inserted);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
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
            await _userRepository.DeleteUser(new User { Id = numero });

            return NoContent();
        }
    }
}
