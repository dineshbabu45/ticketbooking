using BusBooking.Entity;
using BusBooking.Repository;
using System.Collections.Generic;

namespace BusBooking.BL
{
    public class BookingBL
    {
        BusRepository busRepository;
        public BookingBL()
        {
            busRepository = new BusRepository();
        }
        public IEnumerable<Bus> SearchBus(string sourceCity, string destinationCity,string date)
        {
            IEnumerable<Bus> buses = busRepository.SearchBus(sourceCity, destinationCity,date);
            return buses;
        }
        public void AddBus(Bus bus)
        {
            busRepository.AddBus(bus);
        }
            public IEnumerable<Bus> GetBusDetails()
        {
            IEnumerable<Bus> buses = busRepository.GetBusDetails();
            return buses;
        }
        public void DeleteBus(int busId)
        {
            busRepository.DeleteBus(busId);
        }
        public Bus GetBusId(int busId)
        {
           Bus buses = busRepository.GetBusId(busId);
            return buses;
        }
        public void EditBusDetails(Bus bus)
        {
            busRepository.EditBusDetails(bus);
        }
    }
}
