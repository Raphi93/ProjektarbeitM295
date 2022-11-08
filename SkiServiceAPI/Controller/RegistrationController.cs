using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<StatusController> _logger;

        public RegistrationController(IRegistrationServices reg, ILogger<StatusController> logger)
        {
            _regService = reg;
            _logger = logger;
        }

        /// <summary>
        /// Alles Auslessen
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult<List<RegistrationDTO>> GetAll()
        {
            {
                try
                {
                    return _regService.GetAll();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured, {ex.Message}");
                    return NotFound($"Error occured");
                }
            }
        }

        // GET by Id action
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<RegistrationDTO> Get(int id)
        {
            try
            {
                RegistrationDTO r = _regService.Get(id);
                if (r == null)
                    return NotFound();
                return r;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }

        //Post
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create(RegistrationDTO regDTO)
        {
            try
            {
                _regService.Add(regDTO);

                return CreatedAtAction(nameof(Create), new { id = regDTO.Id }, regDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }

        // PUT action
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, RegistrationDTO regDTO)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }

        // DELETE action
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var registration = _regService.Get(id);
                if (registration == null)
                    return NotFound();
                _regService.Delete(id);
                return Content($"Item in row {id} deleted.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }
    }
}
