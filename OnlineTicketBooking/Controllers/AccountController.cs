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
        [AllowAnonymous]
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel,string returnUrl)
        {
               
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<LoginViewModel, Account>();
                });
                IMapper mapper = config.CreateMapper();
                var account = mapper.Map<LoginViewModel, Account>(loginViewModel);
                Account result = accountBL.GetUsersByEmailandPassword(account);
                
                Session["CurrentUserID"] = result.UserId;
                //TempData["UserId"] = result.UserId;

                // var returnUrl = (Request.QueryString["ReturnURL"]);
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(result.EmailId, false);

                    var authUser = new FormsAuthenticationTicket(1, result.EmailId, DateTime.Now, DateTime.Now.AddMinutes(30), false, result.IsAdmin.ToString());
                    string encryptedUser = FormsAuthentication.Encrypt(authUser);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedUser);
                    HttpContext.Response.Cookies.Add(authCookie);
                    //string returnUrl = Convert.ToString(Request.Form["ReturnURL"]);
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        Response.Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Search", "Booking");
                    }
              
                }

                else
                {
                    ViewBag.Message = "Email Id or Password is incorrect";
                    return View("Login");
                }
            }
            return View();
        }
        [AllowAnonymous]
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
                accountBL.AddNewUser(account);
                
                return View(nameof(Login));
            }
            return View();
        }
        [Authorize]
        public ActionResult MyProfile() //Edit User details
        {
            int userId = Convert.ToInt32(Session["CurrentUserID"]);
            //int userId = Convert.ToInt32(TempData["UserId"]);
            Account userDetails = accountBL.GetUsersByUserID(userId);
           
            EditUserViewModel editUserViewModel = new EditUserViewModel() { Name = userDetails.Name, EmailId = userDetails.EmailId, Gender = userDetails.Gender, UserId = userDetails.UserId,Age=userDetails.Age };
            return View(editUserViewModel);
        }
        [HttpPost]
        public ActionResult ChangeProfile(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<EditUserViewModel,Account>();
                });
                IMapper mapper = config.CreateMapper();
                var account = mapper.Map<EditUserViewModel, Account>(editUserViewModel);
                accountBL.UpdateProfile(account);

                return RedirectToAction("Search", "Booking");
            }
            return View(editUserViewModel);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Search", "Booking");
        }
    }
}