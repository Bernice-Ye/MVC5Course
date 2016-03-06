﻿using System;
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
        public ActionResult Index()
        {
            db.Product.Add(new Product()
            {
                ProductName = "BMW",
                Price = 2,
                Stock = 1,
                Active = true,
            });


            var data = db.Product.ToList().OrderByDescending(x => x.ProductId);//.Take(8);
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
    }
}