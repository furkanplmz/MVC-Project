using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class OrderController : Controller
    {
        finalDbEntities2 db = new finalDbEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrder()
        {
            using (finalDbEntities2 db = new finalDbEntities2())
            {
                var Orders = db.OrderTs.ToList();
                return Json(new { data = Orders }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCust()
        {
            using (finalDbEntities2 db = new finalDbEntities2())
            {
                var customers = db.CustomerTs.ToList();
                return Json(new { data = customers }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetProduct()
        {
            using (finalDbEntities2 db = new finalDbEntities2())
            {
                var products = db.ProductTs.ToList();
                return Json(new { data = products }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult Edit(int OrderId)
        {
            var order = db.OrderTs.Where(a => a.OrderId == OrderId).FirstOrDefault();
            return Json(order, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Edit2(int CId)
        {
            var customer = db.CustomerTs.Where(a => a.CId == CId).FirstOrDefault();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Edit3(int ProductId)
        {
            var product = db.ProductTs.Where(a => a.ProductId == ProductId).FirstOrDefault();
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Remove(int OrderId)
        {
            bool status = false;
            var order = db.OrderTs.FirstOrDefault(a => a.OrderId == OrderId);
            if (order != null)
            {
                db.OrderTs.Remove(order);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
        public ActionResult save(OrderT order)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (finalDbEntities2 db = new finalDbEntities2())
                {
                    if (order.OrderId > 0)
                    {
                        var v = db.OrderTs.Where(a => a.OrderId == order.OrderId).FirstOrDefault();
                        if (v != null)
                        {
                            v.CustId = order.CustId;
                            v.CustName = order.CustName;
                            v.CustSurname = order.CustSurname;
                            v.TotalAmount = order.TotalAmount;
                            db.Entry(v).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        db.OrderTs.Add(order);
                    }
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}