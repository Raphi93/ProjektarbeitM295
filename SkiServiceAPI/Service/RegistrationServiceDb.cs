using Microsoft.EntityFrameworkCore;
using SkiServiceAPI.DTO;
using SkiServiceAPI.Models;
using System.Data;

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

        /// <summary>
        /// Gibt alles aus ausser Status = Gelöscht
        /// </summary>
        /// <returns>alle angaben</returns>
        /// <exception cref="Exception">Include fehler oder Datenbank</exception>
        public List<RegistrationDTO> GetAll()
        {
            try
            {
                reg = _dbContext.Registration.Include("Status").Include("Priority").Include("Service").ToList();

                List<RegistrationDTO> result = new List<RegistrationDTO>();
                reg = reg.Where(e => e.Status?.StatusName != "Gelöscht").ToList();
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gibt alle infos von der Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Alle dtaeen von der id</returns>
        /// <exception cref="Exception">Datenbank fehler</exception>
        public RegistrationDTO? Get(int id)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Fügt Daten hinzu
        /// </summary>
        /// <param name="regist"></param>
        /// <exception cref="Exception">Datenbank fehler</exception>
        public void Add(RegistrationDTO regist)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update von den Bestehende einträgen
        /// </summary>
        /// <param name="regist"></param>
        /// <exception cref="Exception">Datenbank fehler</exception>
        public void Update(RegistrationDTO regist)
        {
            try
            {
                var reg = _dbContext.Registration.Where(e => e.Id == regist.Id).FirstOrDefault();
                if (reg != null)
                {
                    reg.Name = regist.Name;
                    reg.EMail = regist.EMail;
                    reg.Phone = regist.Phone;
                    reg.Kommentar = regist.Kommentar;
                    reg.CreateDate = regist.CreateDate;
                    reg.PickupDate = regist.PickupDate;
                    reg.Status = _dbContext.Status.FirstOrDefault(e => e.StatusName == regist.Status);
                    reg.Priority = _dbContext.Priority.FirstOrDefault(e => e.PriorityName == regist.Priority);
                    reg.Service = _dbContext.Service.FirstOrDefault(e => e.ServiceName == regist.Service);
                }

                _dbContext.Entry(reg).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

