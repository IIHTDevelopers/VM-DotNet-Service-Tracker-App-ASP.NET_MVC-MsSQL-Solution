
using ServiceTrackerApp.Models;
using System.Data.Entity;

namespace ServiceTrackerApp.DAL
{
    public class ServiceTrackerDbContext : DbContext
    {
        public ServiceTrackerDbContext()
            : base("name=DefaultConnectionString")
        {
        }
        public DbSet<Service> Services { get; set; }
    }
}