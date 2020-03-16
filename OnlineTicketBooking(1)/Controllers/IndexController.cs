using BusBooking.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTicketBooking.Models;
using BusBooking.BL;

namespace OnlineTicketBooking.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        BookingBL bookingBL;

        public IndexController()
        {
            bookingBL = new BookingBL();
        }
        public ActionResult Index()
        {
            IEnumerable<Bus> bus = bookingBL.GetBusDetails();
            return View(bus);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BusViewModel busViewModel)
        {

            if (ModelState.IsValid)
            {
                Bus bus = new Bus();
                bus.BusId = busViewModel.BusId;
                bus.BusType = busViewModel.BusType;
                bus.TravelsName = busViewModel.TravelsName;
                bus.SourceCity = busViewModel.SourceCity;
                bus.DestinationCity = busViewModel.DestinationCity;
                bus.Price = busViewModel.Price;
                bus.SeatsAvailable = busViewModel.SeatsAvailable;
                bus.StartPoint = busViewModel.StartPoint;
                bus.EndPoint = busViewModel.EndPoint;
                 bookingBL.AddBus(bus);

                TempData["Message"] = "Bus detail added successfully!!!";
                return RedirectToAction("Index");

            }

            return View();

        }
        public ActionResult Delete(int id)
        {
            bookingBL.DeleteBus(id);
            TempData["Message"] = "Bus Detail deleted successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Bus bus = bookingBL.GetBusId(id);
            return View(bus);
        }
        [HttpPost]
        public ActionResult Update(EditBusViewModel editBusViewModel)
        {
            Bus editBus = new Bus();
            editBus.BusId = editBusViewModel.BusId;
            editBus.BusType = editBusViewModel.BusType;
            editBus.TravelsName = editBusViewModel.TravelsName;
            editBus.SourceCity = editBusViewModel.SourceCity;
            editBus.DestinationCity = editBusViewModel.DestinationCity;
            editBus.Price = editBusViewModel.Price;
            editBus.SeatsAvailable = editBusViewModel.SeatsAvailable;
            editBus.StartPoint = editBusViewModel.StartPoint;
            editBus.EndPoint = editBusViewModel.EndPoint;
            bookingBL.EditBusDetails(editBus);
            TempData["Message"] = "Bus Details Edited successfully!!";
            return RedirectToAction("Index");
        }
    }
}