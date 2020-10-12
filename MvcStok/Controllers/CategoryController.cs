using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MvcStok.Controllers
{
    public class CategoryController : Controller
    {


        // GET: Category
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Category(/*int page=1*/)
        {
            List<TBLKATEGORILER> values = db.TBLKATEGORILER.Where(m => m.DURUM == true).ToList();

            //DIFFERENT PAGİNG...
            //var values = db.TBLKATEGORILER.ToList().ToPagedList(page, 4);
            return View(values);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TBLKATEGORILER p1)
        {
            /*if (!ModelState.IsValid)
            {
                return View("Create");
            }*/
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Category");
        }

        public ActionResult Delete(int id)
        {
            var category = db.TBLKATEGORILER.Find(id);
            category.DURUM = false;

            db.SaveChanges();
            return RedirectToAction("Category");
        }

        public ActionResult CategoryGet(int id)
        {

            var category = db.TBLKATEGORILER.Find(id);
            return View("CategoryGet", category);
        }

        public ActionResult Update(TBLKATEGORILER p1)
        {

            var category = db.TBLKATEGORILER.Find(p1.KATEGORIID);
            category.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Category");
        }
    }
}