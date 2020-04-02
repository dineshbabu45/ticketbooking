using BusBooking.Entity;
using BusBooking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.BL
{
    public interface IBookingBL
    {
        Bus GetBusId(int busId);
        void AddBooking(Booking bus);
    }
    public class BookingBL:IBookingBL
    {
        BookingRepository bookingRepository;
        public BookingBL()
        {
            bookingRepository = new BookingRepository();
        }
        public Bus GetBusId(int busId)
        {
            Bus bus = bookingRepository.GetBusId(busId);

            return bus;
        }
        public void AddBooking(Booking bus)
        {
            bookingRepository.AddBooking(bus);
        }
    }
}
