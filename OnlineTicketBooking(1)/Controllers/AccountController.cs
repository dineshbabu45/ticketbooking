using BusBooking.BL;
using BusBooking.Entity;
using BusBooking.Repository;
using System.Linq;
using System.Web.Mvc;
using OnlineTicketBooking.Models;

namespace OnlineTicketBooking.Controllers
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
                Account result = accountBL.Login(account);
                if(result!=null)
                {
                    Session["EmailId"] = result.EmailId.ToString();
                    Session["Password"] = result.Password.ToString();
                    return RedirectToAction("Search","Booking");
                }
                ViewBag.Message = string.Format("Email Id or Password is incorrect");
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
                
                return View("Login");
            }
            return View();
        }
    }
}