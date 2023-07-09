using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        finalDbEntities2 db = new finalDbEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetEmployee()
        {
            using (finalDbEntities2 db = new finalDbEntities2())
            {
                var Employees = db.EmployeeTs.ToList();
                return Json(new { data = Employees }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult Edit(int Id)
        {
            var employee = db.EmployeeTs.Where(a=>a.Id==Id).FirstOrDefault();
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Remove(int Id)
        {
            bool status = false;
            var employee = db.EmployeeTs.FirstOrDefault(a=>a.Id==Id);
            if (employee!=null)
            {
                db.EmployeeTs.Remove(employee);
                db.SaveChanges();
                status = true;
            }
            return new JsonResult { Data=new {status = status} };
        }
        public ActionResult save(EmployeeT employee)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (finalDbEntities2 db= new finalDbEntities2())
                {
                    if (employee.Id > 0)
                    {
                        var v = db.EmployeeTs.Where(a => a.Id == employee.Id).FirstOrDefault();
                        if (v != null)
                        {
                            v.EmployeeName = employee.EmployeeName;
                            v.Surname = employee.Surname;
                            v.Position = employee.Position;
                            v.Office = employee.Office;
                            v.Salary = employee.Salary;

                            db.Entry(v).State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        db.EmployeeTs.Add(employee);
                    }
                        db.SaveChanges();
                        status = true;
                    }
                }
            return new JsonResult { Data = new { status = status } };
        }
    }
}