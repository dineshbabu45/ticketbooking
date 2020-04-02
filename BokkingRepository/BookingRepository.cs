using BusBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Repository
{
    public interface IBookingRepository
    {
        void AddBooking(Booking bus);
        Bus GetBusId(int busId);
    }
    public class BookingRepository:IBookingRepository
    {
        public void AddBooking(Booking bus) //add new booking to database by customer
        {
            using (BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                busTicketBookingDb.Bookings.Add(bus);
                busTicketBookingDb.SaveChanges();

            }
        }
        public Bus GetBusId(int busId) //fetch bus details by using BusID
        {
            using (BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                return busTicketBookingDb.Buses.Find(busId);
            }
        }
    }
}
