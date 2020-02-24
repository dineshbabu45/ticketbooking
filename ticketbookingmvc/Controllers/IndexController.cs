using Booking.Repository;
using BusBooking.Entity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ticketbookingmvc.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        BusRepository bookingRepository;
        public IndexController()
        {
            bookingRepository = new BusRepository();
        }
        public ActionResult Index()
        {
            IEnumerable<Bus> bus = bookingRepository.GetBusDetails();
            return View(bus);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection formCollection)
        {
            try
            {
               Bus bus = new Bus();
                //bus.TravelsName = formCollection["TravelsName"];
                //bus.BusId = Convert.ToInt32(formCollection["BusId"]);
                //bus.SourceCity = formCollection["SourceCity"];
                //bus.DestinationCity = formCollection["DestinationCity"];
                //bus.Price = Convert.ToDouble(formCollection["Price"]);
                if (TryUpdateModel(bus))                  //////////////////TryUpdateModel..
                {
                    bookingRepository.AddBus(bus);
                    TempData["Message"] = "Bus detail added successfully!!!";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            bookingRepository.DeleteBus(id);
            TempData["Message"] = "Bus Detail deleted successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Bus bus = bookingRepository.GetBusId(id);
                return View(bus);
        }
        [HttpPost]
        public ActionResult Update(Bus bus)
        {
            bookingRepository.EditBusDetails(bus);
            TempData["Message"] = "Bus Details Edited successfully!!";
            return RedirectToAction("Index");
        }
    }
}