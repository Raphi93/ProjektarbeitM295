using Microsoft.EntityFrameworkCore;
using SkiServiceAPI.DTO;
using SkiServiceAPI.Models;

namespace SkiServiceAPI.Service
{
    public class RegistrationServiceDb : IRegistrationServices
    {
        private readonly RegistrationContext _dbContext;

        public List<Registration> reg = new List<Registration>();

        public RegistrationServiceDb(RegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<RegistrationDTO> GetAll()
        {

            reg = _dbContext.Registration.Include("Status").Include("Priority").Include("Service").ToList();

            List<RegistrationDTO> result = new List<RegistrationDTO>();
            reg.ForEach(r => result.Add(new RegistrationDTO()
            {
                Id = r.Id,
                Name = r.Name,
                EMail = r.EMail,
                Phone = r.Phone,
                Priority = r.Priority.PriorityName,
                Service = r.Service.ServiceName,
                Status = r.Status.StatusName,
                Kommentar = r.Kommentar,
                CreateDate = (DateTime)r.CreateDate,
                PickupDate = (DateTime)r.PickupDate
            }));
            return result;
        }

        public RegistrationDTO? Get(int id)
        {
            List<RegistrationDTO> t = GetAll();

            RegistrationDTO r = t.Find(p => p.Id == id);

            return new RegistrationDTO()
            {
                Id = r.Id,
                Name = r.Name,
                EMail = r.EMail,
                Phone = r.Phone,
                Priority = r.Priority,
                Service = r.Service,
                Status = r.Status,
                Kommentar = r.Kommentar,
                CreateDate = r.CreateDate,
                PickupDate = r.PickupDate
            };
        }

        public void Add(RegistrationDTO regist)
        {

            Registration reg = new Registration()
            {
                Name = regist.Name,
                EMail = regist.EMail,
                Phone = regist.Phone,
                Kommentar = regist.Kommentar,
                CreateDate = regist.CreateDate,
                PickupDate = regist.PickupDate,
                Status = _dbContext.Status.FirstOrDefault(e => e.StatusName == regist.Status),
                Priority = _dbContext.Priority.FirstOrDefault(e => e.PriorityName == regist.Priority),
                Service = _dbContext.Service.FirstOrDefault(e => e.ServiceName == regist.Service)
            };

            _dbContext.Add(reg);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var reg = _dbContext.Registration.Find(id);

            _dbContext.Registration.Remove(reg);
            _dbContext.SaveChanges();
        }

        public void Update(RegistrationDTO regist)
        {
            var reg = _dbContext.Registration.Where(e => e.Id == regist.Id).FirstOrDefault();
            if (reg != null)
            {
                reg.Name = regist.Name;
                reg.EMail = regist.EMail;
                reg.Phone = regist.Phone;
                reg.Kommentar= regist.Kommentar;
                reg.CreateDate = regist.CreateDate;
                reg.PickupDate = regist.PickupDate;
                reg.Status = _dbContext.Status.FirstOrDefault(e => e.StatusName == regist.Status);
                reg.Priority = _dbContext.Priority.FirstOrDefault(e => e.PriorityName == regist.Priority);
                reg.Service = _dbContext.Service.FirstOrDefault(e => e.ServiceName == regist.Service);
            }

            _dbContext.Entry(reg).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
