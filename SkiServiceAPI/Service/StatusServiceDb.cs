using Microsoft.EntityFrameworkCore;
using SkiServiceAPI.DTO;
using SkiServiceAPI.Models;

namespace SkiServiceAPI.Service
{
    public class StatusServiceDb : IStatusService
    {
        private readonly RegistrationContext _dbContext;
        public List<Status> Status = new List<Status>();

        public StatusServiceDb(RegistrationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<StatusDTO> GetAll()
        {
            Status = _dbContext.Status.Include("Registration").Include("Registration.Priority").Include("registration.Service").ToList();

            List<StatusDTO> result = new List<StatusDTO>();

            foreach (var s in Status)
            {
                var status = new StatusDTO();
                status.StatusId = (int)s.StatusId;
                status.StatusName = s.StatusName;

                foreach (var r in s.Registrations)
                {
                    RegistrationDTO sReg = new RegistrationDTO();

                    sReg.Id = r.Id;
                    sReg.Name = r.Name;
                    sReg.EMail = r.EMail;
                    sReg.Phone = r.Phone;
                    sReg.CreateDate = (DateTime)r.CreateDate;
                    sReg.PickupDate = (DateTime)r.PickupDate;
                    sReg.Kommentar = r.Kommentar;

                    sReg.Priority = r.Priority.PriorityName;
                    sReg.Service = r.Service.ServiceName;
                    sReg.Status = s.StatusName;

                    status.Registration.Add(sReg);
                }
                result.Add(status);
            }
            return result;

        }

        public StatusDTO GetStatus(string status)
        {
            List<StatusDTO> t = GetAll();
            StatusDTO result = t.Find(p => p.StatusName == status);
            return result;
        }
    }
}
