using BusBooking.Entity;
using System.Data.Entity;

namespace BusBooking.Repository
{
    public class BusTicketBookingDbContext : DbContext
    {
        public BusTicketBookingDbContext() : base("BusTicketBookingDbContext") { }


        public DbSet<Account> Accounts { get; set; }
       public DbSet<Bus> Buses { get; set; }
    }
}
