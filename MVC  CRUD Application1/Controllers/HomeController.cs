using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC__CRUD_Application1.Models;

namespace MVC__CRUD_Application1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/  Creating object of DataContext class
        codeitEntities db = new codeitEntities();
        //
        // Getting the all Employee Class Objects
        public ActionResult Index()
        {
         List<Emp> emplist =   db.Emps.ToList();
            return View(emplist);
        }  
        //GET:/Home/ Getting ALL cities from model class
        public ActionResult Create()
        {
            //List<string> listycity = (List<string>)TempData["cityname"];
           

         //  ViewBag.Cities = new SelectList(db.Emps,"Empid", "Location");
          // ViewBag.Cities = db.Emps.ToList();
            ViewBag.Cities = db.Cities.ToList();
           //ViewData["cityname"] = listycity;
            return View();
        }
       
         //POST://Home/     insering the Employee details into Database
        [HttpPost]
        public ActionResult Create(Emp obj)
        {
           try
    
           { 
               
                db.Emps.Add(obj);
                db.SaveChanges();
                
            }
            catch(System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)

           {
               Response.Write(ex.InnerException.Message);
             
            }





           return RedirectToAction("Index");
        }
        //GET:Getting employee Details based on Employee id
        public ActionResult Delete(int id)
        {

         Emp obj  = db.Emps.SingleOrDefault(e1 => e1.Empid == id);
         return View(obj);
                
        }
        //POST: Deleting Employee Details 
    [HttpPost]
        public ActionResult Delete(string id)
        {
           int eno = Convert.ToInt32(id);
           Emp obj= db.Emps.SingleOrDefault(e1 => e1.Empid == eno);
           db.Emps.Remove(obj);
           db.SaveChanges();
           return RedirectToAction("Index");

        }
        //GET: Getting Employee Details based on id
    public ActionResult Edit(int id)
    {
       Emp obj =db.Emps.SingleOrDefault(e1 => e1.Empid == id);
       return View(obj);

    }
        //POST: Updating the Employee Details based on id
        [HttpPost]
    public ActionResult Edit(Emp obj2)
    {
     Emp obj1  = db.Emps.SingleOrDefault(e1 => e1.Empid == obj2.Empid);
     obj1.Empname = obj2.Empname;
     obj1.Sal = obj2.Sal;
     obj1.Location = obj2.Location;
     db.SaveChanges();
     return RedirectToAction("Index");
    }
        //GET:Getting the single Employee Record Based on id
        public ActionResult Details(int id)
        {
           Emp obj= db.Emps.SingleOrDefault(e1 => e1.Empid == id);
           return View(obj);
        }
        //public ActionResult AddLocation()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult AddLocation(string cityName)
        //{


        //    List<string> listcity = new List<string>();
        //    listcity.Add(cityName);
        //   //return RedirectToAction("Create");


        //    return View(listcity);
        //}
        //GET: Returns The view for adding the city
        public ActionResult AddCity()

        { 
            return View();
           
        }
        //POST: Inserting the cityname into Database
        [HttpPost]
        public ActionResult AddCity(City obj)
        {
            //List<string> listcity = new List<string>();
            //listcity.Add(cityname);

            //TempData["cityname"] = listcity;
            db.Cities.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Create","Home");
        }
    

    }
}
