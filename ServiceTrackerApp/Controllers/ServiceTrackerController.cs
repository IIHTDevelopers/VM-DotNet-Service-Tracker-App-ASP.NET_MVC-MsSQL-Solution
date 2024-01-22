using ServiceTrackerApp.DAL.Interface;
using ServiceTrackerApp.DAL.Repository;
using ServiceTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ServiceTrackerApp.Controllers
{
    public class ServiceTrackerController : Controller
    {
        private readonly IServiceTrackerInterface _Repository;
        public ServiceTrackerController(IServiceTrackerInterface service)
        {
            _Repository = service;
        }
        public ServiceTrackerController()
        {
            // Constructor logic, if needed
        }
        // GET: ServiceTracker
        public ActionResult Index()
        {
            var Services = from work in _Repository.GetServices()
                        select work;
            return View(Services);
        }

        public ViewResult Details(int id)
        {
            Service Service =   _Repository.GetServiceByID(id);
            return View(Service);
        }

        public ActionResult Create()
        {
            return View(new Service());
        }

        [HttpPost]
        public ActionResult Create(Service Service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Repository.InsertService(Service);
                    _Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(Service);
        }

        public ActionResult EditAsync(int id)
        {
            Service Service =  _Repository.GetServiceByID(id);
            return View(Service);
        }
        [HttpPost]
        public ActionResult Edit(Service Service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _Repository.UpdateService(Service);
                    _Repository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(Service);
        }

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            Service Service =  _Repository.GetServiceByID(id);
            return View(Service);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Service Service =  _Repository.GetServiceByID(id);
                _Repository.DeleteService(id);
                _Repository.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete",
                   new System.Web.Routing.RouteValueDictionary {
        { "id", id },
        { "saveChangesError", true } });
            }
            return RedirectToAction("Index");
        }
    }
}