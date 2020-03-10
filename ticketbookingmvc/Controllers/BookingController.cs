using BusBooking.Entity;
using BusBooking.Repository;
using System.Collections.Generic;
using System.Web.Mvc;
using ticketbookingmvc.Models;
using BusBooking.BL;

namespace ticketbookingmvc.Controllers
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
            IEnumerable<Bus> buses= bookingBL.SearchBus(searchViewModel.SourceCity, searchViewModel.DestinationCity);

            searchViewModel.Buses = buses;
            return View("Search", searchViewModel);
        }

      
    }
}