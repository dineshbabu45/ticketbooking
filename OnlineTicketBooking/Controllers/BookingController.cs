﻿using BusBooking.Entity;

using System.Collections.Generic;
using System.Web.Mvc;
using OnlineTicketBooking.Models;
using BusBooking.BL;

namespace OnlineTicketBooking.Controllers
{
    public class BookingController : Controller
    {
        BookingBL bookingBL;
        public BookingController()
        {
            bookingBL = new BookingBL();
        }

        // GET: Booking
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchViewModel searchViewModel)
        {
            IEnumerable<Bus> buses= bookingBL.SearchBus(searchViewModel.SourceCity, searchViewModel.DestinationCity,searchViewModel.Date);

            searchViewModel.Buses = buses;
            return View("Search", searchViewModel);
        }
        public ActionResult Filter()
        {
            return View();
        }
      
    }
}