using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cobra_onboarding.Models;

namespace Cobra_onboarding.Controllers
{
    public class c2Controller : Controller
    {
        // GET: c2
        
        
        public ActionResult CustomerListView()
        {
            
            return View();
        }
        
        public ActionResult CustomerList()
        {
            Entities db = new Entities();
            db.Configuration.LazyLoadingEnabled = false;
            return Json(db.People.ToList(),JsonRequestBehavior.AllowGet);
        }


        //Edit
        [HttpGet]
        public ActionResult Edit(int? id)
        {                       
            return View();
        }

        public ActionResult GetCustomerById(int? id)
        {

            Entities db = new Entities();
            Person cus = db.People.Where(a => a.Id == id).FirstOrDefault();
            return Json(cus,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(Person person)
        {
         if (person.Name.Length > 0)
            {
                Entities db = new Entities();
                var newcus = db.People.Find(person.Id);
                newcus.Name = person.Name;
                newcus.Address1 = person.Address1;
                newcus.Address2 = person.Address2;
                newcus.City = person.City;
                db.SaveChanges();
                return RedirectToAction("CustomerListView", "c2");
            }
            
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        //OrderByDate
        [HttpGet]
        public ActionResult OrderbyDate()
        {
            Entities db = new Entities();
            return View(db.OnboarddbViews.ToList());
        }

        //Add
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            if ((person.Name.Length > 0))
            {
                Entities db = new Entities();
                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("CustomerListView", "c2");
            }
            return Json(person, JsonRequestBehavior.AllowGet);
        }

        
    }

}