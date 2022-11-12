using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiServiceAPI.DTO;
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
        /// Alle Werte Aulessen Ausser "Gelöscht"
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler oder alle werte leer ist</exception>
        /// <returns>IRegistration GetAll</returns>
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

        /// <summary>
        /// Auslessen per id
        /// </summary>
        /// <param name="id">Id</param>
        ///<exception cref="Exception">Datenbank fehler oder Id noch nicht existriert</exception>
        /// <returns>IRegistration Get</returns>
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

        /// <summary>
        /// Post methde Hinzufügen der Daten
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler</exception>
        /// <param name="regDTO">RegistzrtionDTO</param>
        /// <returns>Die angaben wo man gemacht hat als return</returns>
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


        /// <summary>
        /// Put methode ändern der daten
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler oder Id noch nicht existriert</exception>
        /// <param name="id">Id</param>
        /// <param name="regDTO">RegistzrtionDTO</param>
        /// <returns>Die angaben wo man gemacht hat als return</returns>
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

                e.Status = "Offen";
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

        /// <summary>
        /// Delete Methode die den Status Gelöscht angibt
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler oder Id noch nicht existriert</exception>
        /// <param name="id">Id</param>
        /// <returns>Die angaben wo man gemacht hat als return</returns>
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                RegistrationDTO e = _regService.Get(id);
                if (e == null)
                    return NotFound();

                e.Status = "Gelöscht";

                _regService.Update(e);
                return CreatedAtAction(nameof(Create), new { id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }
    }
}
