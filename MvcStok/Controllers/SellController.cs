using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using System.Data.SqlClient;

namespace MvcStok.Controllers
{
    public class SellController : Controller
    {
        // GET: Sell

        

    MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Sell()
        {
            var values = db.TBLSATISLAR.ToList();
            return View(values);
        }
        
        [HttpGet]
        public ActionResult Selling()
        {
            List<SelectListItem> valuesproduct = (from i in db.TBLURUNLER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.URUNAD,
                                               Value = i.URUNID.ToString()
                                           }).ToList();
            List<SelectListItem> valuescustomer = (from i in db.TBLMUSTERILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.MUSTERIAD,
                                               Value = i.MUSTERIID.ToString()
                                           }).ToList();

            
            ViewBag.valueproduct = valuesproduct;
            ViewBag.valuecustomer = valuescustomer;
            return View();
        }
        [HttpPost]
        public ActionResult Selling(TBLSATISLAR p2)
        {
            var product = db.TBLURUNLER.Where(m => m.URUNID == p2.TBLURUNLER.URUNID).FirstOrDefault();
            var customer = db.TBLMUSTERILER.Where(m => m.MUSTERIID == p2.TBLMUSTERILER.MUSTERIID).FirstOrDefault();
            p2.TBLURUNLER = product;
            p2.TBLMUSTERILER = customer;
            db.TBLSATISLAR.Add(p2);
            db.SaveChanges();
            return RedirectToAction("Sell");
        }
    }
}