using BusBooking.BL;
using BusBooking.Entity;
using System.Web.Mvc;
using AutoMapper;
using OnlineTicketBooking.Models;
using System.Web.Security;
using System;
using System.Web;

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
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<LoginViewModel, Account>();
                });
                IMapper mapper = config.CreateMapper();
                var account = mapper.Map<LoginViewModel, Account>(loginViewModel);
                Account result = accountBL.Login(account);
             
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(result.EmailId, false);

                    var authUser = new FormsAuthenticationTicket(1, result.EmailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, result.IsAdmin.ToString());
                    string encryptedUser = FormsAuthentication.Encrypt(authUser);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedUser);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Search", "Booking");
                }

                else
                {
                    TempData["Message"] = ("Email Id or Password is incorrect");
                    return View("Login");
                }
            }
            return View();
        }
        //
        ///
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Search","Booking");
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
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<SignUpViewModel, Account>();
                });
                IMapper mapper = config.CreateMapper();
                var account = mapper.Map<SignUpViewModel, Account>(signUpViewModel);
                accountBL.SignUp(account);
                
                return View(nameof(Login));
            }
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}