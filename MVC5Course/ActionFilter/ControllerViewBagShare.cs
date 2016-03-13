using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
     public class ControllerViewBagShareAttribute : ActionFilterAttribute
    {
         public override void OnActionExecuting(ActionExecutingContext filterContext)
         {
             filterContext.Controller.ViewBag.Message = "測試一個共用的ActionFilter";
             base.OnActionExecuting(filterContext);
         }
    }
}
