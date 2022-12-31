using ISIParkAPI.Data;
using ISIParkAPI.Data.Repositories.Interfaces;
using ISIParkAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISIParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private MySQLConfiguration _connectionString;
        static UserDTO user = new UserDTO();

        public AuthController(IConfiguration configuration, IUserRepository userRepository, MySQLConfiguration connectionString)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        [HttpPost("register")]
        public async Task<ActionResult> InsertUser([FromBody]UserDTO request)
        {
            if (request == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            request.PasswordHash = passwordHash;
            request.PasswordSalt = passwordSalt;

            var inserted = await _userRepository.InsertUser(request);
            return Created("created", inserted);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLogin request)
        {
            if (!_userRepository.GetUserByEm(request.Email))
                return BadRequest("User not found!");

            var ph = _userRepository.GetUserByPasswordh(request.Email);
            var ps = _userRepository.GetUserByPasswords(request.Email);
            Console.WriteLine(ph);

            if (!VerifyPasswordHash(request.Password, ph, ps))
                return BadRequest("Wrong Password!");

            user = await _userRepository.GetUserByEmail(request.Email);

            if((user.Email == "admin") && (user.Password == "admin"))
            {
                string tokenA = CreateTokenAdmin(user);
                return Ok(tokenA);
            }

            string token = CreateToken(user);
            return Ok(token);
        }
        private string CreateTokenAdmin(UserDTO user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private string CreateToken(UserDTO user)
        {
            List<Claim> claims = new List<Claim>
            {         
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "User")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
