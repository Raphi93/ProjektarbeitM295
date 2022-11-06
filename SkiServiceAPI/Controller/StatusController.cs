using Microsoft.AspNetCore.Http;
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

        public StatusController(IStatusService status)
        {
            _statService = status;
        }

        [HttpGet]
        public ActionResult<List<StatusDTO>> GetAll()
        {
            return _statService.GetAll();
        }

        [HttpGet("{status}")]
        public ActionResult<StatusDTO> GetByStatus(string status)
        {
            return _statService.GetStatus(status);
        }
    }
}
