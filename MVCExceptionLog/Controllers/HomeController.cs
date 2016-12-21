using MVCExceptionLog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCExceptionLog.Controllers
{
    [HandleError(ExceptionType = typeof(NullReferenceException), View = "SomeException")]
    public class HomeController : Controller
    {
        ApplicationModel ctx = new ApplicationModel();
        // GET: Employee

       
        public ActionResult Index()
        {
            var Emps = ctx.Employees.ToList();
            return View(Emps);
        }

        public ActionResult Create()
        {
            return View(new EmployeeInfo());
        }

        //[ExceptionHandler]
        [HttpPost]
        public ActionResult Create(EmployeeInfo Emp)
        {

            if (Emp.Designation == "Manager" && (Emp.Salary < 40000 || Emp.Salary > 80000))
            {
                //throw new Exception("Salary is not Matching with Manager Designatgion");
                int value = 0;
                value /= value;
            }
            else
            if (Emp.Designation == "Operator" && (Emp.Salary < 10000 || Emp.Salary > 20000))
            {
                throw new Exception("Salary is not Matching with Operator Designatgion");
            }
            else
            {
                ctx.Employees.Add(Emp);
                ctx.SaveChanges();

            }
            return View(Emp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            int a = 0;
            int b;
            b = 1 / a;
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }

    
}