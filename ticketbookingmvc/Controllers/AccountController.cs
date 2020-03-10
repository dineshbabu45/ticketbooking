using BusBooking.BL;
using BusBooking.Entity;
using BusBooking.Repository;
using System.Linq;
using System.Web.Mvc;
using ticketbookingmvc.Models;

namespace ticketbookingmvc.Controllers
{
    public class AccountController : Controller
    {
        AccountBL accountBL;
        public AccountController()
        {
            accountBL=new AccountBL();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.EmailId = loginViewModel.EmailId;
                account.Password = loginViewModel.Password;

                return View();
            }
            return View();
        }
       
           
        public ActionResult SignUp()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(SignUpViewModel signUpViewModel)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.EmailId = signUpViewModel.EmailId;
                account.Password = signUpViewModel.Password;
                account.Gender = signUpViewModel.Gender;
                account.Name = signUpViewModel.Name;
                account.Age = signUpViewModel.Age;
                accountBL.SignUp(account);
                //accountContext.Accounts.Add(account);
                //accountContext.SaveChanges();
                return View("Login");
            }
            return View();
        }
    }
}