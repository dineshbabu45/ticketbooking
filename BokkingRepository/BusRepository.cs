using BusBooking.Entity;
using System.Collections.Generic;
using System.Linq;

namespace BusBooking.Repository
{
    public class BusRepository
    {
       
        public static List<Bus> buses = new List<Bus>();
      
        static BusRepository()
        {
            buses.Add(new Bus { TravelsName = "A1 Travels", BusId = 1, SourceCity = "Chennai", DestinationCity = "CBE", Price = 1500,SeatsAvailable=40,StartPoint="Gandhipuram",EndPoint="Koyambedu" });
            buses.Add(new Bus { TravelsName = "Orange Travels", BusId = 2, SourceCity = "CBE", DestinationCity = "Trichy", Price = 1000, SeatsAvailable = 40, StartPoint = "Gandhipuram", EndPoint = "Trichy" });
            buses.Add(new Bus { TravelsName = "KPR", BusId = 3, SourceCity = "Chennai", DestinationCity = "Bangalore", Price = 900, SeatsAvailable = 40, StartPoint = "Koyambedu", EndPoint = "Bangalore" });
        }
       public List<Bus> SearchBus(string sourceCity, string destinationCity)
        {
            using(BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                List<Bus> buses = busTicketBookingDb.Buses.Where(temp => temp.SourceCity == sourceCity && temp.DestinationCity == destinationCity).ToList();

                return buses;
            }

        }
        public IEnumerable<Bus> GetBusDetails()
        {
            using (BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                List<Bus> buses = busTicketBookingDb.Buses.ToList();

                return buses;
            }
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
