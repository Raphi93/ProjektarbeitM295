using Microsoft.EntityFrameworkCore;
using SkiServiceAPI.DTO;
using SkiServiceAPI.Models;
using System.Net.NetworkInformation;

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
        /// <summary>
        /// Get Mothode alle daten vom Status
        /// </summary>
        /// <returns>Ausgabe der daten</returns>
        /// <exception cref="Exception">Fehler der datenbank</exception>
        public List<StatusDTO> GetAll()
        {
            try
            {
                Status = _dbContext.Status.Include("Registrations").Include("Registrations.Priority").Include("Registrations.Service").ToList();
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

                        status.Registration.OrderBy(i => i.Priority);

                        status.Registration.Add(sReg);
                    }
                    result.Add(status);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Je nach Namen Alle Einträge
        /// </summary>
        /// <param name="status">Name des Status</param>
        /// <returns>Ausgabe der daten</returns>
        /// <exception cref="Exception">Datenbank fehler</exception>
        public StatusDTO GetStatus(string status)
        {
            try
            {
                List<StatusDTO> t = GetAll();
                StatusDTO result = t.Find(p => p.StatusName == status);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
