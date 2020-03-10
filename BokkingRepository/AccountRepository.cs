using BusBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Repository
{
    public class AccountRepository
    {
        public void Signup(Account account)
        {
            using (BusTicketBookingDbContext accountContext = new BusTicketBookingDbContext())
            {
                accountContext.Accounts.ToList();
                accountContext.Accounts.Add(account);
                accountContext.SaveChanges();
            }
        }
        public Account Login(Account account)
        {
            
                using (BusTicketBookingDbContext accountContext = new BusTicketBookingDbContext())
                {
                List<Bus> buses = accountContext.Buses.Find();

                    return buses;
                }

            
        }
    }
}
