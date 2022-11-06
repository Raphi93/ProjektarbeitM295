using Microsoft.AspNetCore.Mvc;
using SkiServiceAPI.Models;
using SkiServiceAPI.Service;
using SkiServiceAPI.DTO;
using System.Runtime.Intrinsics.X86;
using static SkiServiceAPI.Service.IJwtService;

namespace SkiServiceAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        public List<User> Users { get; set; } = new List<User>();
        private readonly IJwtService _jwtService;

        public UserTokenController(IJwtService jwtservice)
        {
            _jwtService = jwtservice;
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] UserDTO user)
        {
            Users = _jwtService.Login();

            foreach (User key in Users)
            {
                if (user.UserName == key.UserName && user.Password == key.Password)
                {
                    return new JsonResult(new { userName = user.UserName, token = _jwtService.CreateToken(user.UserName) });
                }
                else
                {
                    return Unauthorized("Invalid Credentials");
                }
            }
            return NoContent();
        }
    }
}
