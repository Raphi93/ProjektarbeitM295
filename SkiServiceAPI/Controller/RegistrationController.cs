using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SkiServiceAPI.DTO;
using SkiServiceAPI.Models;
using SkiServiceAPI.Service;


namespace SkiServiceAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationServices _regService;

        public RegistrationController(IRegistrationServices reg)
        {
            _regService = reg;
        }

        /// <summary>
        /// Alles Auslessen
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<RegistrationDTO>> GetAll() => _regService.GetAll();

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<RegistrationDTO> Get(int id)
        {

            RegistrationDTO r = _regService.Get(id);
            if (r == null)
                return NotFound();
            return r;

        }
        // POST action
        [HttpPost]
        public IActionResult Create(RegistrationDTO regDTO)
        {
            _regService.Add(regDTO);

            return CreatedAtAction(nameof(Create), new { id = regDTO.Id }, regDTO);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, RegistrationDTO regDTO)
        {
            RegistrationDTO e = _regService.Get(id);
            if (e == null)
                return NotFound();
               
        

            _regService.Update(e);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, RegistrationDTO regDTO)
        {
            
            return NoContent();
        }
    }
}
