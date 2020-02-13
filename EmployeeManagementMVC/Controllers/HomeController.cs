using EmployeeManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        
        EmployeeDBEntities db = new EmployeeDBEntities();
        public ActionResult Index()
        {
            return View(db.tbl_Employee.ToList());
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeViewModel model)
        {
            if(ModelState.IsValid)
            {

                tbl_Employee obj = new tbl_Employee(); ;
                obj.FirstName = model.FirstName;
                obj.LastName = model.LastName;
                obj.Gender = model.Gender;
                obj.DOB = model.DOB;
                obj.ContactNo = model.ContactNo;
                obj.Address = model.Address;
                obj.Salary = model.Salary;
                db.tbl_Employee.Add(obj);
                db.SaveChanges();
                ModelState.Clear();
            }

            return View();
        }

        
      
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.tbl_Employee.Where(m=>m.ID==id).FirstOrDefault());
        }

       
        [HttpPost]
        public ActionResult Edit(int id, EmployeeViewModel model)
        {
            try
            {

                var obj = db.tbl_Employee.Where(m => m.ID == id).FirstOrDefault();
                if(obj!=null)
                {
                    obj.FirstName = model.FirstName;
                    obj.LastName = model.LastName;
                    obj.Gender = model.Gender;
                    obj.DOB = model.DOB;
                    obj.Address = model.Address;
                    obj.ContactNo = model.ContactNo;
                    obj.Salary = model.Salary;
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

         
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var obj = db.tbl_Employee.Where(m => m.ID == id).FirstOrDefault();
            db.tbl_Employee.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
