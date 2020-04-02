using BusBooking.Entity;
using System.Linq;

namespace BusBooking.Repository
{
    public interface IAccountRepository //Interface
    {
        void Signup(Account account);
        Account Login(Account account);
        Account GetUsersByUserID(int userId);
        void UpdateProfile(Account account);
    }
    public class AccountRepository:IAccountRepository
    {
        public void Signup(Account account) //Register
        {
            using (BusTicketBookingDbContext accountContext = new BusTicketBookingDbContext())
            {
               
                accountContext.Accounts.Add(account);
                accountContext.SaveChanges();
            }
        }
        public Account Login(Account account) //Login 
        {
            
                using (BusTicketBookingDbContext accountContext = new BusTicketBookingDbContext())
                {
                Account result = accountContext.Accounts.Where(temp=>temp.EmailId==account.EmailId&&temp.Password == account.Password).FirstOrDefault();
                //Get account by EmailID and Password
                    return result;
                }

        }
        public Account GetUsersByUserID(int userId)
        {
            using (BusTicketBookingDbContext accountContext = new BusTicketBookingDbContext())
            {
                return accountContext.Accounts.Find(userId);
            }
        }
        public void UpdateProfile(Account account) 
        {
            using (BusTicketBookingDbContext accountContext = new BusTicketBookingDbContext())
            {

                Account updateProfile = accountContext.Accounts.Find(account.UserId);
                updateProfile.EmailId = account.EmailId;
                updateProfile.Name = account.Name;
                updateProfile.Age = account.Age;
                updateProfile.Gender = account.Gender;
                
                accountContext.SaveChanges();
            }
        }
    }
}
