using BusBooking.Entity;
using BusBooking.Repository;


namespace BusBooking.BL
{
    public interface IAccountBL
    {
        void AddNewUser(Account account);
        Account GetUsersByEmailandPassword(Account account);
        Account GetUsersByUserID(int userId);
        void UpdateProfile(Account account);
    }
    public class AccountBL:IAccountBL
    {
        AccountRepository accountRepository;
        public AccountBL()
        {
            accountRepository = new AccountRepository();
        }
        public void AddNewUser(Account account)
        {
            accountRepository.AddNewUser(account);
        }
        public Account GetUsersByEmailandPassword(Account account)
        {
            return accountRepository.GetUsersByEmailandPassword(account);
        }
        public Account GetUsersByUserID(int userId)
        {

            return accountRepository.GetUsersByUserID(userId);

        }
        public void UpdateProfile(Account account)
        {
            accountRepository.UpdateProfile(account);
        }
    }
}
