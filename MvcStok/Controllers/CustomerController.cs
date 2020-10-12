using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Customer(/*string p*/)
        {
            /*
            //DIFFERENT SEARCH...
            var values = from v in db.TBLMUSTERILER select v;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(values.ToList());
            */
            var values = db.TBLMUSTERILER.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Customer");
        }

        public ActionResult Delete(int id)
        {
            var customer = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Customer");
        }

        public ActionResult CustomerGet(int id)
        {
            var customer = db.TBLMUSTERILER.Find(id);
            return View("CustomerGet", customer);
        }

        public ActionResult Update(TBLMUSTERILER p1)
        {
            var customer = db.TBLMUSTERILER.Find(p1.MUSTERIID);
            customer.MUSTERIAD = p1.MUSTERIAD;
            customer.MUSTERISOYAD = p1.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Customer");
        }
    }
}