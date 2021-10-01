using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT2.Areas.Admins.Controllers
{
    [Authorize]
    public class HomeAdminController : Controller
    {
        // GET: Admins/HomeAdmin
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }
    }
}