using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using FormBuilder.DAL;
using FormBuilder.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using FormContext = FormBuilder.DAL.FormContext;

namespace FormBuilder.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private FormContext db = new FormContext();
        private UserLoginService checkUser = new UserLoginService();

        // GET: User Index
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        // POST: User Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("")]
        public ActionResult Login(User user)
        {
            var authenticatedUser = checkUser.GetByUsernameAndPassword(user);
            if (authenticatedUser != null)
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, authenticatedUser.UserName),
                    new Claim(ClaimTypes.NameIdentifier, authenticatedUser.UserId.ToString())
                },
                    DefaultAuthenticationTypes.ApplicationCookie);

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                var claimsPrincipal = new ClaimsPrincipal(identity);
                Thread.CurrentPrincipal = claimsPrincipal;

                authManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
                return RedirectToAction("Index", "Home");
            }

            // user authN failed
            ModelState.AddModelError("Invalid", "Invalid username or password");
            return View("~/Views/User/Index.cshtml", model: user);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,FirstMidName,LastName,EMail,UserName,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
                return View("~/Views/User/Index.cshtml", model: user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "User");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
