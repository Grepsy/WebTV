using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebTV.Model;
using WebTV.Model.Account;

namespace WebTV.Controllers
{
    [HandleError]
    public class AccountController : Controller {

        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext) {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************

        public ActionResult LogOn() {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl) {
            if (ModelState.IsValid) {
                if (MembershipService.ValidateUser(model.UserName, model.Password)) {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    
                    if (!String.IsNullOrEmpty(returnUrl)) {
                        return Redirect(returnUrl);
                    }
                    else {
                        return RedirectToAction("Index", "MediaSet");
                    }
                }
                else {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff() {
            FormsService.SignOut();
            Session.Abandon();

            return RedirectToAction("LogOn");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************
        [Authorize(Roles="Administrator")]
        public ActionResult Register() {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Register(RegisterModel model) {
            if (ModelState.IsValid) {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password," ");

                if (createStatus == MembershipCreateStatus.Success) {
                    //RegisterCustomer(model);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ModelState.AddModelError("", "Failed to create a user");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        private void RegisterCustomer(RegisterModel model)
        {
            //var context = new MightyMusicContext();
            //var customer = new Customer() {
            //    CustomerId = context.Customers.Count() + 256,
            //    FirstName = model.UserName,
            //    LastName = "",
            //    Title = "",
            //    EmailAddress = model.Email,
            //    Password = model.Password,
            //    Date = DateTime.Now,
            //    Confirmed = "yes",
            //    Sale = "",
            //};
            //context.Customers.AddObject(customer);
            //context.SaveChanges();
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword() {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model) {
            if (ModelState.IsValid) {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword)) {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess() {
            return View();
        }
        // **************************************
        // URL: /Account/ListUsers
        // **************************************
        [Authorize(Roles = "Administrator")]
        public ActionResult ListUsers()
        {
            Membership.GetAllUsers();
            return View();
        }
    }
}