using BusBooking.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTicketBooking.Models;
using BusBooking.BL;
using AutoMapper;

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
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<BusViewModel, Bus>();
                });
                IMapper mapper = config.CreateMapper();
                var bus = mapper.Map<BusViewModel, Bus>(busViewModel);

                
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
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EditBusViewModel, Bus>();
            });
            IMapper mapper = config.CreateMapper();
            var editBus = mapper.Map<EditBusViewModel, Bus>(editBusViewModel);
            
            bookingBL.EditBusDetails(editBus);
            TempData["Message"] = "Bus Details Edited successfully!!";
            return RedirectToAction("Index");
        }
    }
}