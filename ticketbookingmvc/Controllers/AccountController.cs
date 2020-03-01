using BusBooking.Entity;
using System.Web.Mvc;

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
        public ActionResult Login(Account account)
        {
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