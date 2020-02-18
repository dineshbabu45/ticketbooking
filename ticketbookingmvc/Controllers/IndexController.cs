using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ticketbooking.Entity;
using Ticketbooking.Repository;

namespace ticketbookingmvc.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        BusRepository busRepository;
        public IndexController()
        {
            busRepository = new BusRepository();
        }
        public ActionResult Index()
        {
            IEnumerable<Bus> bus = busRepository.GetBusDetails();
            return View(bus);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Bus bus)
        {

            busRepository.AddBus(bus);
            TempData["Message"] = "Bus detail added successfully!!!";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            busRepository.DeleteBus(id);
            TempData["Message"] = "Bus Detail deleted successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Bus bus = busRepository.GetBusId(id);
                return View(bus);
        }
        [HttpPost]
        public ActionResult Update(Bus bus)
        {
            busRepository.EditBusDetails(bus);
            TempData["Message"] = "Bus Details Edited successfully!!";
            return RedirectToAction("Index");
        }
    }
}