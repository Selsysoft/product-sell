using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
namespace MvcStok.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Product()
        {
            var values = db.TBLURUNLER.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> values = (from i in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View();
        }
        [HttpPost]
        public ActionResult Create(TBLURUNLER p1)
        {
            var category = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER = category;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Product");
        }

        public ActionResult Delete(int id)
        {
            var product = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
        public ActionResult ProductGet(int id)
        {
            var product = db.TBLURUNLER.Find(id);

            List<SelectListItem> values = (from i in db.TBLKATEGORILER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.KATEGORIAD,
                                               Value = i.KATEGORIID.ToString()
                                           }).ToList();
            ViewBag.value = values;

            return View("ProductGet", product);
        }

        public ActionResult Update(TBLURUNLER p1)
        {
            var product = db.TBLURUNLER.Find(p1.URUNID);
            product.URUNAD = p1.URUNAD;
            product.MARKA = p1.MARKA;
            product.FIYAT = p1.FIYAT;
            product.STOK = p1.STOK;
            //product.URUNKATEGORI = p1.URUNKATEGORI;
            var category = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            product.URUNKATEGORI = category.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Product");

        }
    }
}