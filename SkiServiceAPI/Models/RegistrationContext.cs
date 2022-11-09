using Microsoft.EntityFrameworkCore;

namespace SkiServiceAPI.Models
{
    public partial class RegistrationContext : DbContext
    {
        //PowerShell
        //Add-Migration InitialCreate
        //Update-Database

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=SkiServicePA;Trusted_Connection=True");
        }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }

        public RegistrationContext()
        {
        }
        public RegistrationContext(DbContextOptions<RegistrationContext> options)
            : base(options)
        {
        }
    }
}
