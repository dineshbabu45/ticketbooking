using BusBooking.Entity;
using System.Collections.Generic;
using System.Linq;

namespace BusBooking.Repository
{
    public interface IBusRepository
    {
        IEnumerable<Bus> GetBusDetails();
        List<Bus> SearchBus(string sourceCity, string destinationCity, string Date);
        void AddBus(Bus bus);
        Bus GetBusId(int busId);
        void DeleteBus(int busId);
        void EditBusDetails(Bus bus);
    }
    public class BusRepository:IBusRepository
    {

        public List<Bus> SearchBus(string sourceCity, string destinationCity, string Date) //search done by user
        {

            using (BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                List<Bus> buses = busTicketBookingDb.Buses.Where(temp => temp.SourceCity == sourceCity && temp.DestinationCity == destinationCity && temp.Date == Date).ToList();

                return buses;
            }

        }
        //Admin
        public IEnumerable<Bus> GetBusDetails() //get all bus information from databsae
        {
            using (BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                List<Bus> buses = busTicketBookingDb.Buses.ToList();

                return buses;
            }
        }
        public void AddBus(Bus bus) //Add new bus details
        {
            using (BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                //busTicketBookingDb.Buses.ToList();
                busTicketBookingDb.Buses.Add(bus);
                busTicketBookingDb.SaveChanges();

            }
        }
        public Bus GetBusId(int busId) //fetch particular bus detail by using BusID
        {
            using (BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                return busTicketBookingDb.Buses.Find(busId);
            }
        }
        public void DeleteBus(int busId) //Remove particular bus detail 
        {
            using (BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                Bus bus = busTicketBookingDb.Buses.Find(busId);
                if (bus != null)
                    busTicketBookingDb.Buses.Remove(bus);
                busTicketBookingDb.SaveChanges();
            }
        }
        public void EditBusDetails(Bus bus)
        {
            using (BusTicketBookingDbContext busTicketBookingDb = new BusTicketBookingDbContext())
            {
                //Bus updateBus = GetBusId(bus.BusId);
                Bus updateBus = busTicketBookingDb.Buses.Find(bus.BusId);
                updateBus.TravelsName = bus.TravelsName;
                updateBus.SourceCity = bus.SourceCity;
                updateBus.DestinationCity = bus.DestinationCity;
                updateBus.Price = bus.Price;
                updateBus.BusType = bus.BusType;
                updateBus.SeatsAvailable = bus.SeatsAvailable;
                updateBus.StartPoint = bus.StartPoint;
                updateBus.EndPoint = bus.EndPoint;
                updateBus.Date = bus.Date;
                updateBus.BusTime = bus.BusTime;
                busTicketBookingDb.SaveChanges();

            }
        }
    }
}
