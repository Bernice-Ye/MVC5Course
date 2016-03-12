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
        //FabricsEntities db = new FabricsEntities();
        ProductRepository repo = RepositoryHelper.GetProductRepository();

        // GET: EF
        public ActionResult Index()
        {
            return View(repo.All());
        }

        private void SaveChanges()
        {
            try
            {
                repo.UnitOfWork.Commit();
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
            var data = repo.Find(id);
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var product = repo.Find(id);
            product.IsDelete = true;
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

//        public ActionResult QueryPlan(int num = 10)
//        {
//            //var data = db.Product.Include(o => o.OrderLine).OrderBy(p => p.ProductId).AsQueryable();
//            var data = db.Database.SqlQuery<Product>(@"
//                Select *
//                From dbo.Product P
//                    where P.ProductId < @P0
//                    ", num);

//            return View(data);
//        }
    }
}