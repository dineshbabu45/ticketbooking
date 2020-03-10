using BusBooking.Repository;
using BusBooking.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using ticketbookingmvc.Models;
using BusBooking.BL;

namespace ticketbookingmvc.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        BookingBL bookingBL;
        BusTicketBookingDbContext createContext;
        public IndexController()
        {
            bookingBL = new BookingBL();
            new BusTicketBookingDbContext();
        }
        public ActionResult Index()
        {
            IEnumerable<Bus> bus = bookingBL.GetBusDetails();
            return View(bus);
        }

        public ActionResult Create()
        {

           createContext.Buses.ToList();
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
               // bookingRepository.AddBus(bus);
                createContext.Buses.Add(bus);
                createContext.SaveChanges();
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
        public ActionResult Update(Bus bus)
        {
            bookingBL.EditBusDetails(bus);
            TempData["Message"] = "Bus Details Edited successfully!!";
            return RedirectToAction("Index");
        }
    }
}