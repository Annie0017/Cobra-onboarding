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
        private Entities _db = new Entities();
        public ActionResult CustomerListView()
        {            
            return View();
        }        
        public ActionResult CustomerList()
        {

            _db.Configuration.LazyLoadingEnabled = false;
            return Json(_db.People.ToList(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Add(CustomerEntryViewModel person)
        {
            if ((person != null))
            {
                try {
                    var newcus = new Person(); {
                        newcus.Name = person.Name;
                        newcus.Address1 = person.Add1;
                        newcus.Address2 = person.Add2;
                        newcus.City = person.City;
                         };
                    _db.People.Add(newcus);
                    _db.SaveChanges();
                    return Json(new { success = true, id = newcus.Id });
                }
                catch
                {
                    return Json(new {success = false, id = 0 });
                }
            }
            return Json(new { success = false, id = 0 });
           
        }
        [HttpPost]
        public ActionResult Edit(CustomerEntryViewModel person)
        {
            if (person.Name.Length > 0)
            {
                try
                {
                    var newcus = _db.People.Find(person.Id);
                    newcus.Name = person.Name;
                    newcus.Address1 = person.Add1;
                    newcus.Address2 = person.Add2;
                    newcus.City = person.City;
                    _db.SaveChanges();
                    return Json(new { success = true, id = newcus.Id });
                }
                catch
                {
                    return Json(new { success = false, id = 0 });
                }
            }
            return Json(new { success = false, id = 0 });

        }
        [HttpPost]
        public ActionResult Delete(CustomerEntryViewModel item)
        {           
            {
                try
                {
                    var newcus = _db.People.Find(item.Id);
                    _db.People.Remove(newcus);
                    _db.SaveChanges();
                    return Json(new { success = true, id = item.Id });
                }
                catch
                {
                    return Json(new { success = false, id = 0 });
                }
                
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

            _db.Configuration.LazyLoadingEnabled = false;
            var clist = (from p in _db.Products
                         join o in _db.OrderDetails on p.Id equals o.ProductId
                         join h in _db.OrderHeaders on o.OrderId equals h.OrderId
                         join pp in _db.People on h.PersonId equals pp.Id
                         orderby h.OrderDate
                         select new { h.OrderId, pp, h.OrderDate, p});                   
            return Json(clist.ToList(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductList()
        {

            _db.Configuration.LazyLoadingEnabled = false;
            var plist = (from p in _db.Products                        
                         select new { p.ProductName, p.Price , p.Id});
            return Json(plist.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Prod(string pid)
        {
            if (pid != null)
            {
                
                int PId = Convert.ToInt16(pid);
                var newcu1 = _db.Products.Find(PId);                
                return Json(newcu1.Price);
            }
            return Json("invalid entry");
        }
        [HttpPost]
        public ActionResult AddOrder(OrderClass person)
        {
            if (person != null)
            {
                try
                {

                    var newcus = new OrderHeader();
                    {
                        newcus.OrderDate = DateTime.Now;
                        newcus.PersonId = person.Name;
                    }
                    _db.Configuration.LazyLoadingEnabled = false;
                    _db.OrderHeaders.Add(newcus);
                    _db.SaveChanges();
                    var newcus4 = new OrderDetail();
                    {
                        newcus4.OrderId = newcus.OrderId;
                        newcus4.ProductId = person.Id;
                    }
                    _db.OrderDetails.Add(newcus4);
                    _db.SaveChanges();
                    return Json(new { success = true, id = newcus.OrderId });
                }
                catch
                {
                    return Json(new { success = false, id = 0 });
                }
            }
            return Json(new { success = false, id = 0 });
        }

        [HttpPost]
        public ActionResult EditOrder(OrderClass person)
        {
            if ((person != null))
            {
                try
                {
                    var newcus = _db.OrderHeaders.Find(person.OrderId);
                    {
                        newcus.OrderDate = DateTime.Now;
                        newcus.PersonId = person.Name;
                    }
                    _db.SaveChanges();
                    var newcus2 = _db.OrderDetails.Where(x => x.OrderId == person.OrderId).FirstOrDefault();
                    {
                        newcus2.ProductId = person.Id;
                    }

                    _db.SaveChanges();
                    return Json(new { success = true, id = newcus.OrderId });
                }
                catch
                {
                    return Json(new { success = false, id = 0 });
                }
            }
            return Json(new { success = false, id = 0 });
        }
        [HttpPost]
        public ActionResult OrderDelete(OrderClass item)
        {
            {
                try
                {
                    var newcus2 = _db.OrderDetails.Where(x => x.OrderId == item.OrderId).FirstOrDefault();
                    _db.OrderDetails.Remove(newcus2);
                    _db.SaveChanges();
                    var newcus = _db.OrderHeaders.Find(item.OrderId);
                    _db.OrderHeaders.Remove(newcus);
                    _db.SaveChanges();
                    return Json(new { success = true, id = item.OrderId });
                }
                catch
                {
                    return Json(new { success = false, id = 0 });
                }
            }
          
        }

    }

}