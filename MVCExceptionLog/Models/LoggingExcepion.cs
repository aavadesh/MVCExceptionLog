using Elmah;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCExceptionLog.Models
{
    public class ExceptionHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {


                ExceptionLogger logger = new ExceptionLogger()
                {
                    ExceptionMessage = filterContext.Exception.Message,
                    ExceptionStackTrace = filterContext.Exception.StackTrace,
                    ControllerName = filterContext.RouteData.Values["controller"].ToString(),
                    LogTime = DateTime.Now
                };

                ApplicationModel ctx = new ApplicationModel();
                ctx.ExceptionLoggers.Add(logger);
                ctx.SaveChanges();


                //var viewData = new ViewDataDictionary<HandleErrorInfo>(filterContext.Controller.ViewData);


                filterContext.Result = new ViewResult()
                {
                    ViewName = "SomeException"
                };

                filterContext.ExceptionHandled = true;
            }
        }
    }

    public class ExceptionLogger
    {
        [Key]
        public int Id { get; set; }
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string ExceptionStackTrace { get; set; }
        public DateTime LogTime { get; set; }

    }

    public class EmployeeInfo
    {
        [Key]
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
    }


    
}