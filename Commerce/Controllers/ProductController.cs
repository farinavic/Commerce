using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Commerce.Models;
using System.Data.Entity;

namespace Commerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product/Index
        public ActionResult Index()
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Products.ToList());
            }
                
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (DBModels db=new DBModels())
            {
                return View(db.Products.Where(x=>x.ProductId==id).FirstOrDefault());
            }
            
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                // TODO: Add insert logic here
                using (DBModels db = new DBModels())
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (DBModels db = new DBModels())
            {
                return View(db.Products.Where(x=>x.ProductId==id).FirstOrDefault());
            }
            
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add update logic here
                using (DBModels db=new DBModels())
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (DBModels db=new DBModels())
            {
                return View(db.Products.Where(x => x.ProductId == id).FirstOrDefault());
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add delete logic here
                using (DBModels db = new DBModels())
                {
                    product = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
