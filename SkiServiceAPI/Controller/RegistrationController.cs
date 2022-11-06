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

            e.Name = regDTO.Name;
            e.EMail = regDTO.EMail;
            e.Phone = regDTO.Phone;
            e.CreateDate = regDTO.CreateDate;
            e.PickupDate = regDTO.PickupDate;
            e.Kommentar = regDTO.Kommentar;

            e.Status = regDTO.Status;
            e.Service = regDTO.Service;
            e.Priority = regDTO.Priority;

            _regService.Update(e);

            return CreatedAtAction(nameof(Create), new { id = id }, regDTO);
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, RegistrationDTO regDTO)
        {
            var registration = _regService.Get(id);
            if (registration == null)
                return NotFound();
            _regService.Delete(id);
            return Content($"Item in row {id} deleted.");
        }
    }
}
