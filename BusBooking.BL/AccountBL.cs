using BusBooking.Entity;
using BusBooking.Repository;


namespace BusBooking.BL
{
    public class AccountBL
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
    }
}
