using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(MemberViewModel data)
        {
            return Content(data.Name + " " + data.Birthday);
        }

    }
}