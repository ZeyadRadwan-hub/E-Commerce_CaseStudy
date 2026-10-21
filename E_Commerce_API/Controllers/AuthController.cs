using E_Commerce_API.DTOs;
using E_Commerce_API.Models;
using E_Commerce_API.Repo.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AuthLoginDTO dto)
        {
            var token = await _unitOfWork.CustomAuth.Login(dto);
            if(token == null)
                return Unauthorized();
            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Rigster(AuthRegisterDTO dto)
        {
            var registered = await _unitOfWork.CustomAuth.Register(dto);

            if (registered)
                return Ok("Registered");

            return BadRequest();
                
        }
    }
}
