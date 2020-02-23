using BookingEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Repository
{
    public class BookingRepository
    {
      
        public static List<Bus> buses = new List<Bus>();
        static BookingRepository()
        {
            buses.Add(new Bus { TravelsName = "A1 Travels", BusId = 1, SourceCity = "Chennai", DestinationCity = "CBE", Price = 1500 });
            buses.Add(new Bus { TravelsName = "Orange Travels", BusId = 2, SourceCity = "CBE", DestinationCity = "Trichy", Price = 1000 });
            buses.Add(new Bus { TravelsName = "KPR", BusId = 3, SourceCity = "Chennai", DestinationCity = "Bangalore", Price = 900 });
        }
        public IEnumerable<Bus> GetBusDetails()
        {
            return buses;
        }
        public void AddBus(Bus bus)
        {
            buses.Add(bus);
        }
        public Bus GetBusId(int busId)
        {
            return buses.Find(id => id.BusId == busId);
        }
        public void DeleteBus(int busId)
        {
            Bus bus = GetBusId(busId);
            if (bus != null)
                buses.Remove(bus);
        }
        public void EditBusDetails(Bus bus)
        {
            Bus updateBus = GetBusId(bus.BusId);
            updateBus.SourceCity = bus.SourceCity;
            updateBus.DestinationCity = bus.DestinationCity;
            updateBus.Price = bus.Price;

        }

    }
}
