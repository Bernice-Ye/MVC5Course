using System.Data.Entity;
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
        FabricsEntities db = new FabricsEntities();

        // GET: EF
        public ActionResult Index(bool? IsActive, string keyWord)
        {
            db.Product.Add(new Product()
            {
                ProductName = "BMW",
                Price = 2,
                Stock = 1,
                Active = true,
            });

            var data = db.Product.ToList().OrderByDescending(x => x.ProductId).AsQueryable();

            if (IsActive.HasValue)
            {
                data = data.Where(x => x.Active.HasValue ? x.Active == IsActive : false);
            }

            if (!String.IsNullOrEmpty(keyWord))
            {
                data = data.Where(x => x.ProductName.Contains(keyWord));
            }

            foreach (var item in data)
            {
                item.Price = item.Price + 1;
            }

            SaveChanges();

            return View(data);
        }

        private void SaveChanges()
        {
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
        }


        public ActionResult Detail(int id)
        {
            var data = db.Product.FirstOrDefault(x => x.ProductId == id);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var product = db.Product.Find(id);

            db.OrderLine.RemoveRange(product.OrderLine);
            db.Product.Remove(product);
            SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult QueryPlan(int num = 10)
        {
            //var data = db.Product.Include(o => o.OrderLine).OrderBy(p => p.ProductId).AsQueryable();
            var data = db.Database.SqlQuery<Product>(@"
                Select *
                From dbo.Product P
                    where P.ProductId < @P0
                    ", num);

            return View(data);
        }
    }
}