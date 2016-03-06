using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        // GET: EF
        public ActionResult Index()
        {
            var db = new FabricsEntities();
            db.Product.Add(new Product()
            {
                ProductName = "BMW",
                Price = 1,
                Stock = 1,
                Active = true,
            });
           
            try
            {
                 db.SaveChanges();
            }

            catch (DbEntityValidationException ex)
            {
                var allErrors = new List<string>();
                foreach (DbEntityValidationResult re in ex.EntityValidationErrors)
                {
                    foreach (DbValidationError err in re.ValidationErrors)
                    {
                        throw new Exception(err.ErrorMessage);
                    }

                }
            }

            var data = db.Product.ToList();
            return View(data);
        }
    }
}