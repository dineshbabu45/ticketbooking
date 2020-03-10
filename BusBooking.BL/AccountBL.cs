using BusBooking.Entity;
using BusBooking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Login(Account account)
        {
            accountRepository.Signup(account);
        }
    }
}
