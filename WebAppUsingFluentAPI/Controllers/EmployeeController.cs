using EF6ClassLibraryFluentAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppUsingFluentAPI.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            ViewBag.employee = ManageEmployee.Get();
            return View("Employee");
        }
    }
}