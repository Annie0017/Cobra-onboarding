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

        Entities db = new Entities();
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
        
        //public ActionResult Get(CustomerEntryViewModel person)
        //{
        //    Entities db = new Entities();
        //    var cus = db.People.Find(person.Id);

        //    ////CustomerEntryViewModel model = new CustomerEntryViewModel()
        //    //{

        //    //    Id = cus.Id,
        //    //    Add1 = cus.Address1,
        //    //    Add2 = cus.Address2,
        //    //    City = cus.City,
        //    //    Name = cus.Name

        //    //};
        //    db.SaveChanges();
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}



[HttpPost]
        public ActionResult Edit(CustomerEntryViewModel person)
        {
            if (person.Name.Length > 0)
            {

                var newcus = db.People.Find(person.Id);
                
                    newcus.Name = person.Name;
                    newcus.Address1 = person.Add1;
                    newcus.Address2 = person.Add2;
                    newcus.City = person.City;
                
                    db.SaveChanges();
                
                    return Json(newcus);
                
            }
            return Json("invalid entry");
        }


        [HttpPost]
        public ActionResult Delete(CustomerEntryViewModel item)
        {
           
            {
                Entities db = new Entities();
                var newcus = db.People.Find(item.Id);
                db.People.Remove(newcus);
                db.SaveChanges();
                return Json(newcus);

            }
           
        }
       // OrderByDate
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