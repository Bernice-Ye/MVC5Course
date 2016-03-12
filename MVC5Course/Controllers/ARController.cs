using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View("Index");
        }
        public ActionResult Content()
        {
            return Content("a String");
        }
        public ActionResult FileTest()
        {
            return File(Server.MapPath("~/Content/lamborghini.jpg"), "image/jpeg", "lamborghini.jpg");
        }
    }
}