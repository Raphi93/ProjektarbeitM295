using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SkiServiceAPI.Models;
using SkiServiceAPI.Service;


namespace SkiServiceAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegisteredServices _registrationService;

        public RegistrationController(IRegisteredServices registarion)
        {
            _registrationService = registarion;
        }
        // GET all action
        [HttpGet]
        public ActionResult<List<RegistrationDTO>> GetAll()
        {
            if (_registrationService.RegistrationDTO == null)
            {
                return NotFound();
            }
            return await _registrationService.RegistrationDTO.ToListAsync();
        }
        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<RegistrationDTO> Get(int id)
        {

        }
        // POST action
        [HttpPost]
        public IActionResult Create(RegistrationDTO reg)
        {

        }
        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(RegistrationDTO reg)
        {

        }
        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

        }
    }
}
