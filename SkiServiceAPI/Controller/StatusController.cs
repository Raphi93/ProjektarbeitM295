using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkiServiceAPI.DTO;
using SkiServiceAPI.Service;

namespace SkiServiceAPI.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private IStatusService _statService;
        private readonly ILogger<StatusController> _logger;

        public StatusController(IStatusService status, ILogger<StatusController> logger)
        {
            _statService = status;
            _logger = logger;
        }

        /// <summary>
        /// Alle status Auslessen mit der Registrationen
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler oder es hat noch keine daten</exception>
        /// <returns>IStatusService GetAll</returns>
        [Authorize]
        [HttpGet]
        public ActionResult<List<StatusDTO>> GetAll()
        {
            try
            {
                return _statService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }


        /// <summary>
        /// Status Auslessen mit der Registrationen by Id
        /// </summary>
        /// <exception cref="Exception">Datenbank fehler oder Id noch nicht existriert</exception>
        /// <param name="status"></param>
        /// <returns>IStatusService Get</returns>
        [Authorize]
        [HttpGet("{status}")]
        public ActionResult<StatusDTO> GetByStatus(string status)
        {
            try
            {
                return _statService.GetStatus(status);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured, {ex.Message}");
                return NotFound($"Error occured");
            }
        }
    }
}
