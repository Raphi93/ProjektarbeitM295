using SkiServiceAPI.DTO;

namespace SkiServiceAPI.Service
{
    public interface IStatusService
    {
        List<StatusDTO> GetAll();

        StatusDTO GetStatus(string status);
    }
}
