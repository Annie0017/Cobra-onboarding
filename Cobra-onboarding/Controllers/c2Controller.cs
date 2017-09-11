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
        public ActionResult Add(Person person)
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
                         select new { h.OrderId, pp, h.OrderDate, p});
           
            //var result = from c in clist.AsEnumerable() select new { c.OrderDate.ToString("dd MMM yyy") };
            return Json(clist.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductList()
        {
            Entities db = new Entities();
            db.Configuration.LazyLoadingEnabled = false;

            var plist = (from p in db.Products
                        
                         select new { p.ProductName, p.Price , p.Id});

            return Json(plist.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Prod(string pid)
        {
            if (pid != null)
            {
                Entities db = new Entities();
                int PId = Convert.ToInt16(pid);
              var newcu1 = db.Products.Find(PId);
                
                return Json(newcu1.Price);
            }
            return Json("invalid entry");
        }
        [HttpPost]
        public ActionResult AddOrder(OrderClass person)
        {
            if (person != null)
            {
                Entities db = new Entities();                
                var newcus = new OrderHeader();
                {
                    newcus.OrderDate = DateTime.Now;
                    newcus.PersonId = person.Name;
                }
                db.Configuration.LazyLoadingEnabled = false;
                db.OrderHeaders.Add(newcus);
                db.SaveChanges();
               
                var newcus4 = new OrderDetail();
                {                    
                    newcus4.OrderId = newcus.OrderId;
                    newcus4.ProductId = person.Id;
                }
                
                db.OrderDetails.Add(newcus4);
                 db.SaveChanges();

                return Json(newcus4);
            }
            return Json("invalid entry");
        }

       

        [HttpPost]
        public ActionResult EditOrder (OrderClass person)
        {
            if ((person != null))
            {
                Entities db = new Entities();
                var newcus = db.OrderHeaders.Find(person.OrderId);
                {
                    newcus.OrderDate = DateTime.Now;
                    newcus.PersonId = person.Name;
                }
                db.SaveChanges();
                var newcus2 = db.OrderDetails.Where(x => x.OrderId == person.OrderId).FirstOrDefault();
                              
                {
                    //newcus2.OrderId = newcus.OrderId;
                    newcus2.ProductId = person.Id;
                }

                db.SaveChanges();

                //return Json(newcus4);
            }
            return Json("invalid entry");
        }
        [HttpPost]
        public ActionResult OrderDelete(OrderClass item)
        {

            {
                Entities db = new Entities();
                var newcus2 = db.OrderDetails.Where(x => x.OrderId == item.OrderId).FirstOrDefault();
                db.OrderDetails.Remove(newcus2);
                db.SaveChanges();
                var newcus = db.OrderHeaders.Find(item.OrderId);
                db.OrderHeaders.Remove(newcus);
                db.SaveChanges();
                
                return Json(newcus);

            }

        }

    }

}