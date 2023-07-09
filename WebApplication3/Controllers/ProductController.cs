using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ProductController : Controller
    {
        finalDbEntities2 db = new finalDbEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetProduct()
        {
            using (finalDbEntities2 db = new finalDbEntities2())
            {
                var Products = db.ProductTs.ToList();
                return Json(new { data = Products }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult Edit(int ProductId)
        {
            var product = db.ProductTs.Where(a => a.ProductId == ProductId).FirstOrDefault();
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Remove(int ProductId)
        {
            bool status = false;
            var product = db.ProductTs.FirstOrDefault(a => a.ProductId == ProductId);
            if (product != null)
            {
                db.ProductTs.Remove(product);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
        public ActionResult save(ProductT product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (finalDbEntities2 db = new finalDbEntities2())
                {
                    if (product.ProductId > 0)
                    {
                        var v = db.ProductTs.Where(a => a.ProductId == product.ProductId).FirstOrDefault();
                        if (v != null)
                        {
                            v.ProductName = product.ProductName;
                            v.Quantity = product.Quantity;
                            v.Price = product.Price;
                            v.Description = product.Description;
                            db.Entry(v).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        db.ProductTs.Add(product);
                    }
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}