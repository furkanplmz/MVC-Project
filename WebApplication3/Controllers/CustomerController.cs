using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CustomerController : Controller
    {
        finalDbEntities2 db = new finalDbEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCustomer()
        {
            using (finalDbEntities2 db = new finalDbEntities2())
            {
                var Customers = db.CustomerTs.ToList();
                return Json(new { data = Customers }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult Edit(int CId)
        {
            var customer = db.CustomerTs.Where(a => a.CId == CId).FirstOrDefault();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Remove(int CId)
        {
            bool status = false;
            var customer = db.CustomerTs.FirstOrDefault(a => a.CId == CId);
            if (customer != null)
            {
                db.CustomerTs.Remove(customer);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }



        public ActionResult save(CustomerT customer)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (finalDbEntities2 db = new finalDbEntities2())
                {
                    if (customer.CId > 0)
                    {
                        var v = db.CustomerTs.Where(a => a.CId == customer.CId).FirstOrDefault();
                        if (v != null)
                        {
                            v.CustomerName = customer.CustomerName;
                            v.CustomerSurname = customer.CustomerSurname;
                            v.CustomerPhone = customer.CustomerPhone;
                            db.Entry(v).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        db.CustomerTs.Add(customer);
                    }
                    db.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}