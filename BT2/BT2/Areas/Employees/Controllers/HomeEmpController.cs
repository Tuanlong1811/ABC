using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT2.Areas.Employees.Controllers
{
    [Authorize(Roles ="nv")]
    public class HomeEmpController : Controller
    {
        // GET: Employees/HomeEmp
        public ActionResult Index()
        {
            return View();
        }
    }
}