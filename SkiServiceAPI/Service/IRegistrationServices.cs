using SkiServiceAPI.DTO;

namespace SkiServiceAPI.Service
{
    public interface IRegistrationServices
    {
        public List<RegistrationDTO> GetAll();
        public RegistrationDTO? Get(int id);
        public void Add(RegistrationDTO reg);
        public void Delete(int id);
        public void Update(RegistrationDTO reg);
    }
}
