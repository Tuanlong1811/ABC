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

        [AllowAnonymous]





        public ActionResult Login(string returnUrl)
        {
            if (CheckSession() == 1)
            {
                return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
            }
            else if (CheckSession() == 2)
            {
                return RedirectToAction("Index", "HomeEmp", new { Area = "Employees" });
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Account acc, string returnUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(acc.UserName) && !string.IsNullOrEmpty(acc.Password))
                {
                    using (var db = new LTQLDbConText())
                    {
                        var passToMD5 = ecry.PasswordEncrytion(acc.Password);
                        var account = db.Accounts.Where(m => m.UserName.Equals(acc.UserName) && m.Password.Equals(passToMD5)).Count();
                        if (account == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UserName, false);
                            Session["idUser"] = acc.UserName;
                            Session["roleUser"] = acc.RoleID;
                            return RedirectToLocal(returnUrl);
                        }
                        ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");
                    }
                }

                ModelState.AddModelError("", "Username and password is required.");
            }
            catch
            {
                ModelState.AddModelError("", "Hệ thống đang được bảo trì, vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {

            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admins" });
                }
                else if (CheckSession() == 2)

                {
                    return RedirectToAction("Index", "HomeEmp", new { Area = "Employees" });
                }

            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult Login(Account acc, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string encrytionpass = ecry.PasswordEncrytion(acc.Password);
        //        var model = db.Accounts.Where(m => m.UserName == acc.UserName && m.Password == encrytionpass).ToList().Count();
        //        if (model == 1)
        //        {
        //            FormsAuthentication.SetAuthCookie(acc.UserName, true);
        //            return RedirectToLocal(returnUrl);
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Thong tin không chính xác");
        //        }

        //    }
        //    return View(acc);
        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //private ActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        //Kiểm tra người dùng đăng nhập quyền gì
        private int CheckSession()
        {
            using (var db = new LTQLDbConText())
            {
                var user = HttpContext.Session["idUser"];

                if (user != null)
                {
                    var role = db.Accounts.Find(user.ToString()).RoleID;

                    if (role != null)
                    {
                        if (role.ToString() == "Admin")

                        {
                            return 1;
                        }

                        else if (role.ToString() == "nv")

                        {
                            return 2;
                        }
                    }
                }
            }
            return 0;
        }
    }
}