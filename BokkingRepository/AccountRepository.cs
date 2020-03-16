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
                Account result = accountContext.Accounts.Where(temp=>temp.EmailId==account.EmailId&&temp.Password == account.Password).FirstOrDefault();

                    return result;
                }

            
        }
    }
}
