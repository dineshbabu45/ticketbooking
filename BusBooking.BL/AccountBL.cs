using BusBooking.Entity;
using BusBooking.Repository;


namespace BusBooking.BL
{
    public interface IAccountBL
    {
        void SignUp(Account account);
        Account Login(Account account);
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
        public void SignUp(Account account)
        {
            accountRepository.Signup(account);
        }
        public Account Login(Account account)
        {
            return accountRepository.Login(account);
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
