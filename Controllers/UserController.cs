using AutoMapper;
using LearnASP.Core.Contracts;
using LearnASP.Dtos;
using LearnASP.Dtos.User;
using LearnASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnASP.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            (User res, String token) = await _unitOfWork.User.Login(loginDto);
            var userDto = _mapper.Map<UserDto>(res);
            return Ok(new { data = res, token = token, message = "Login success" });
        }
    }
}
