using Microsoft.EntityFrameworkCore;
using SkiServiceAPI.DTO;
using SkiServiceAPI.Models;
using System.Numerics;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;



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
            reg = _dbContext.Registrations.Include("User").Include("Service").Include("Priorities").Include("State").ToList();
            List<RegistrationDTO> result = new List<RegistrationDTO>();
            reg.ForEach(r => result.Add(new RegistrationDTO()
            {
                Id = r.Id,
                Name = r.Name,
                EMail = r.EMail,
                Phone = r.Phone,
                Priority = r.Priority.Priority,
                Service = r.Service.Service,
                Status = r.State.Status,
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
                PickupDate = regist.CreateDate,
                CreateDate = regist.CreateDate,
                Kommentar = regist.Kommentar,
                Name = regist.Name,
                Phone = regist.Phone,
                EMail= regist.EMail,

            };
            reg.State = _dbContext.Status.FirstOrDefault(e => e.Status.Equals(regist.Status, StringComparison.OrdinalIgnoreCase));
            reg.Priority = _dbContext.Priorities.FirstOrDefault(e => e.Priority.Equals(regist.Status, StringComparison.OrdinalIgnoreCase));
            reg.Service = _dbContext.Services.FirstOrDefault(e => e.Service.Equals(regist.Status, StringComparison.OrdinalIgnoreCase));
            _dbContext.Add(reg);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var reg = _dbContext.Registrations.Find(id);

            _dbContext.Registrations.Remove(reg);
            _dbContext.SaveChanges();
        }

        public void Update(RegistrationDTO regist)
        {
            var reg = _dbContext.Registrations.Where(r => r.Id == regist.Id).FirstOrDefault();
            if (reg != null)
            {
                reg.PickupDate = regist.CreateDate;
                reg.CreateDate = regist.CreateDate;
                reg.Kommentar = regist.Kommentar;
                reg.Name = regist.Name;
                reg.Phone = regist.Phone;
                reg.EMail = regist.EMail;
                reg.State = _dbContext.Status.FirstOrDefault(e => e.Status.Equals(regist.Status, StringComparison.OrdinalIgnoreCase));
                reg.Priority = _dbContext.Priorities.FirstOrDefault(e => e.Priority.Equals(regist.Status, StringComparison.OrdinalIgnoreCase));
                reg.Service = _dbContext.Services.FirstOrDefault(e => e.Service.Equals(regist.Status, StringComparison.OrdinalIgnoreCase));
            }
            _dbContext.Entry(reg).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
