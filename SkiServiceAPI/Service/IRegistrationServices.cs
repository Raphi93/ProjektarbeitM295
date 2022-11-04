using SkiServiceAPI.Models;

namespace SkiServiceAPI.Service
{
    public interface IRegistrationServices
    {
        List<RegistrationDTO> GetAll();
        RegistrationDTO? Get(int id);
        void Add(RegistrationDTO reg);
        public void Delete(int id);
        void Update(RegistrationDTO reg);
    }
}
