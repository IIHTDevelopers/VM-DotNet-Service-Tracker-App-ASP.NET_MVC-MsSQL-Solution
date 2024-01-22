using ServiceTrackerApp.DAL.Interface;
using ServiceTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ServiceTrackerApp.DAL.Repository
{
    public class ServiceTrackerRepository : IServiceTrackerRepository
    {
        private ServiceTrackerDbContext _context;
        public ServiceTrackerRepository(ServiceTrackerDbContext Context)
        {
            this._context = Context;
        }
        public IEnumerable<Service> GetServices()
        {
             return _context.Services.ToList();
        }
        public Service GetServiceByID(int id)
        {
            return _context.Services.Find(id);
        }
        public Service InsertService(Service Service)
        {
            return _context.Services.Add(Service);
        }
        public int DeleteService(int ServiceID)
        {
            Service Service = _context.Services.Find(ServiceID);
            var res= _context.Services.Remove(Service);
            return res.Id;
        }
        public bool UpdateService(Service Service)
        {
            var res= _context.Entry(Service).State = EntityState.Modified;
            return res.Equals("Service");
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
