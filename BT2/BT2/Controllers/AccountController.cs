using BT2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BT2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        Encrytion ecry = new Encrytion();
        LTQLDbConText db = new LTQLDbConText();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(Account acc)
        {
            if (ModelState.IsValid)
            {
                acc.Password = ecry.PasswordEncrytion(acc.Password);
                db.Accounts.Add(acc);
                db.SaveChanges();
                return RedirectToAction("Login", "Account");
            }
            return View(acc);
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(Account acc,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string encrytionpass = ecry.PasswordEncrytion(acc.Password);
                var model = db.Accounts.Where(m => m.UserName == acc.UserName && m.Password == encrytionpass).ToList().Count();
                if(model == 1)
                {
                    FormsAuthentication.SetAuthCookie(acc.UserName, true);
                    return RedirectToLocal(returnUrl);
                }else
                {
                    ModelState.AddModelError("", "Thong tin không chính xác");
                }
                
            }
            return View(acc);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}