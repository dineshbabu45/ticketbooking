using BusBooking.Entity;
using System.Web.Mvc;
using ticketbookingmvc.Models;

namespace ticketbookingmvc.Controllers
{
    public class AccountController : Controller
    {
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
        public ActionResult SignUp(Account account)
        {
            return View();
        }
    }
}