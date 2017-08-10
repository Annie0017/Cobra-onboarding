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
            Person person = null;
            Entities db = new Entities();
            if (id.HasValue)
            {
                person = db.People.First(x => x.Id == id.Value);
            }
            else
            {
                person = new Person();
            }                       
            return View(person);
        }

        [HttpPut]
        public ActionResult Edit(Person person)
        { 
            {
                Entities db = new Entities();
                db.People.Add(person);
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