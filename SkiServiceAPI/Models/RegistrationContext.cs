using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SkiServiceAPI.Models
{
    public partial class RegistrationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=SkiServicePA;Trusted_Connection=True");
        }
        public DbSet<Priorities> Priorities { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<User> Users { get; set; }

        public RegistrationContext()
        {
        }
        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {
        }
    }
}
