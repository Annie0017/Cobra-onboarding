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
        //[HttpGet]
        //public ActionResult OrderbyDate()
        //{
        //    Entities db = new Entities();
        //    return View(db.OnboarddbViews.ToList());
        //}
        public ActionResult OrderBy()
        {
            return View();
        }
        public ActionResult OrderByList()
        {
            Entities db = new Entities();
            db.Configuration.LazyLoadingEnabled = false;

            var clist = (from p in db.Products
                         join o in db.OrderDetails on p.Id equals o.ProductId
                         join h in db.OrderHeaders on o.OrderId equals h.OrderId
                         join pp in db.People on h.PersonId equals pp.Id
                         orderby h.OrderDate
                         select new { h.OrderId, pp.Name, h.OrderDate, p.ProductName, p.Price });

            return Json(clist.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductList()
        {
            Entities db = new Entities();
            db.Configuration.LazyLoadingEnabled = false;

            var plist = (from p in db.Products
                        
                         select new { p.ProductName, p.Price });

            return Json(plist.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Prod(OrderClass person)
        {
            if (person != null)
            {
                Entities db = new Entities();
                var newcu1 = db.People.Find(person);
                var newcus = new Product();

                {
                    newcus.Price = person.Price;

                }
                return Json(newcus);
            }
            return Json("invalid entry");
        }
        [HttpPost]
        public ActionResult AddOrder(OrderClass person)
        {
            if (person != null)
            {
                Entities db = new Entities();
                var newcu1 = db.People.Find(person);
                var newcus = new OrderHeader();

                {
                    newcus.OrderDate = person.OrderDate;
                    newcus.PersonId = newcu1.Id;
                }

                db.OrderHeaders.Add(newcus);

                db.SaveChanges();
                var newcu3 = db.Products.Find(person);
                var newcus4 = new OrderDetail();
                {
                    newcus4.ProductId = newcu3.Id;
                    newcus4.OrderId = newcus.OrderId;
                }
                db.OrderDetails.Add(newcus4);

                db.SaveChanges();

                return Json(newcus);
            }
            return Json("invalid entry");
        }

        [HttpPost]
        public ActionResult Add(Person person)
        {
            if ((person!=null))
            {
                Entities db = new Entities();
                db.People.Add(person);
                db.SaveChanges();
                return Json(person);
            }
            return Json("invalid entry");
        }

        [HttpPost]
        public ActionResult EditOrder (Person person)
        {
            if ((person != null))
            {
                Entities db = new Entities();
                db.People.Add(person);
                db.SaveChanges();
                return Json(person);
            }
            return Json("invalid entry");
        }
        [HttpPost]
        public ActionResult OrderDelete(CustomerEntryViewModel item)
        {

            {
                Entities db = new Entities();
                var newcus = db.People.Find(item.Id);
                db.People.Remove(newcus);
                db.SaveChanges();
                return Json(newcus);

            }

        }

    }

}