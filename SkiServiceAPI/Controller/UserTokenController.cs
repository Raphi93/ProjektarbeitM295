using Microsoft.AspNetCore.Mvc;
using SkiServiceAPI.Models;
using SkiServiceAPI.Service;
using SkiServiceAPI.DTO;
using System.Runtime.Intrinsics.X86;
using static SkiServiceAPI.Service.IJwtService;
using Microsoft.AspNetCore.Authorization;

namespace SkiServiceAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        public List<User> Users { get; set; } = new List<User>();
        private readonly IJwtService _jwtService;
        private readonly ILogger<StatusController> _logger;

        public UserTokenController(IJwtService jwtservice, ILogger<StatusController> logger)
        {
            _jwtService = jwtservice;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDTO user)
        {
            try
            {
                Users = _jwtService.Login();

                foreach (User key in Users)
                {
                    if (user.UserName == key.UserName && user.Password == key.Password)
                    {
                        return new JsonResult(new { token = _jwtService.CreateToken(user.UserName) });
                    }
                    else
                    {
                        return Unauthorized("Invalid Credentials");
                    }
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }
    }
}
