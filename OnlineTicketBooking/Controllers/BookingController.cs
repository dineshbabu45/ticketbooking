using BusBooking.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTicketBooking.Models;
using BusBooking.BL;
using AutoMapper;
using System;

namespace OnlineTicketBooking.Controllers
{
    public class BookingController : Controller
    {
        BusBL busBL;
        BookingBL bookingBL;
        
        public BookingController()
        {

            busBL = new BusBL();
            bookingBL = new BookingBL();
        }

        // GET: Booking
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchViewModel searchViewModel) //searching for bus
        {
            IEnumerable<Bus> buses= busBL.SearchBus(searchViewModel.SourceCity, searchViewModel.DestinationCity,searchViewModel.Date);

            searchViewModel.Buses = buses;
            return View("Search", searchViewModel);
        }

        public ActionResult Create(int id) //adding booking details to database
        {
           Bus bus = bookingBL.GetBusId(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Bus, BookingViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var book = mapper.Map<Bus, BookingViewModel>(bus);
           
            return View(book);

        }
        [HttpPost]
      [Authorize]
        public ActionResult Create(BookingViewModel bookingViewModel,int id)
        {
            ViewBag.Buses = bookingBL.GetBusId(id);
            //bookingViewModel.Bus = ViewBag.Buses;
           
            bookingViewModel.BookingDate = DateTime.Now;
            bookingViewModel.TravelsName = ViewBag.Buses.TravelsName;
            bookingViewModel.SourceCity = ViewBag.Buses.SourceCity;
            bookingViewModel.DestinationCity = ViewBag.Buses.DestinationCity;
            bookingViewModel.Date = ViewBag.Buses.Date;
            bookingViewModel.Price = ViewBag.Buses.Price;
            bookingViewModel.StartPoint = ViewBag.Buses.StartPoint;
            bookingViewModel.EndPoint = ViewBag.Buses.EndPoint;
            bookingViewModel.BusTime = ViewBag.Buses.BusTime;
            
           
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BookingViewModel, Booking>();
            });
            IMapper mapper = config.CreateMapper();
            var book = mapper.Map<BookingViewModel, Booking>(bookingViewModel);
            if (Request.IsAuthenticated)
            {

                bookingBL.AddBooking(book);
            }
            
           
            return View();
        }
        public ActionResult Help()
        {
            return View();
        }

    }
}