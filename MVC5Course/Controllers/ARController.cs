using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
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
        public ActionResult JsonTest()
        {
            FabricsEntities db = new FabricsEntities();
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(3);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}