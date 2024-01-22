using ServiceTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTrackerApp.DAL.Interface
{
    public interface IServiceTrackerInterface 
    {
        IEnumerable<Service> GetServices();
        Service GetServiceByID(int ServiceId);
        Service InsertService(Service Service);
        int DeleteService(int ServiceId);
        bool UpdateService(Service Service);
        void Save();
    }
}