using BusBooking.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTicketBooking.Models;
using BusBooking.BL;
using AutoMapper;
using OnlineTicketBooking.Filter;

namespace OnlineTicketBooking.Controllers
{
    [LogCustomExceptionFilter]
    [Authorize(Roles = "True")]
    public class BusController : Controller
    {
        // GET: Index
        BusBL busBL;
        public BusController()
        {
            busBL = new BusBL();
        }
        
        public ActionResult Index() //show all bus details from database
        {
            IEnumerable<Bus> bus = busBL.GetBusDetails();
            return View(bus);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BusViewModel busViewModel) //adding new bus details
        {

            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<BusViewModel, Bus>();
                });
                IMapper mapper = config.CreateMapper();
                var bus = mapper.Map<BusViewModel, Bus>(busViewModel);

                
                 busBL.AddBus(bus);

                TempData["Message"] = "Bus detail added successfully!!!";
                return RedirectToAction("Index");

            }

            return View();

        }
        public ActionResult Delete(int id)
        {
            busBL.DeleteBus(id);
            TempData["Message"] = "Bus Detail deleted successfully";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id) //edit bus details
        {
            Bus bus = busBL.GetBusId(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap< Bus,BusViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var buses = mapper.Map<Bus, BusViewModel>(bus);
            return View(buses);
        }
        [HttpPost]
        public ActionResult Update(EditBusViewModel editBusViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EditBusViewModel, Bus>();
            });
            IMapper mapper = config.CreateMapper();
            var editBus = mapper.Map<EditBusViewModel, Bus>(editBusViewModel);
            
            busBL.EditBusDetails(editBus);
            TempData["Message"] = "Bus Details Edited successfully!!";
            return RedirectToAction("Index");
        }
    }
}