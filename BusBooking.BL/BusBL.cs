using BusBooking.Entity;
using BusBooking.Repository;
using System.Collections.Generic;

namespace BusBooking.BL
{
    public interface IBusBL
    {
        IEnumerable<Bus> SearchBus(string sourceCity, string destinationCity, string date);
        Bus GetBusId(int busId);
        void AddBus(Bus bus);
        IEnumerable<Bus> GetBusDetails();
        void DeleteBus(int busId);
        void EditBusDetails(Bus bus);

    }
    public class BusBL:IBusBL
    {
        BusRepository busRepository;
        public BusBL()
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
            Bus bus = busRepository.GetBusId(busId);

            return bus;
        }
        public void EditBusDetails(Bus bus)
        {
            busRepository.EditBusDetails(bus);
        }
    }
}
