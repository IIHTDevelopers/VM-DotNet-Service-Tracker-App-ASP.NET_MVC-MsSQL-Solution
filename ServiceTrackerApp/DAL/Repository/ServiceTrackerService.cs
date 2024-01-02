using ServiceTrackerApp.DAL.Interface;
using ServiceTrackerApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceTrackerApp.DAL.Repository
{
    public class ServiceTrackerService : IServiceTrackerInterface
    {
        private IServiceTrackerRepository _repo;
        public ServiceTrackerService(IServiceTrackerRepository repo)
        {
            this._repo = repo;
        }

        public int DeleteService(int ServiceId)
        {
            var res= _repo.DeleteService(ServiceId);
            return res;
        }

        public Service GetServiceByID(int ServiceId)
        {
            return _repo.GetServiceByID(ServiceId);
        }
        public void Save()
        {
            _repo.Save();
        }


        IEnumerable<Service> IServiceTrackerInterface.GetServices()
        {
            return _repo.GetServices();
        }

        Service IServiceTrackerInterface.InsertService(Service Service)
        {
            return _repo.InsertService(Service);
        }

        bool IServiceTrackerInterface.UpdateService(Service Service)
        {
            return _repo.UpdateService(Service);
        }
    }
}