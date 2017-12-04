using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class PRODUCT_CATEGORIESController : Controller
    {
        private WEBSHOPEntities db = new WEBSHOPEntities();

        // GET: PRODUCT_CATEGORIES
        public ActionResult Index()
        {
            var pRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Include(p => p.CATEGORIES).Include(p => p.PRODUCTS);
            return View(pRODUCT_CATEGORIES.ToList());
        }

        // GET: PRODUCT_CATEGORIES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_CATEGORIES pRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Find(id);
            if (pRODUCT_CATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_CATEGORIES);
        }

        // GET: PRODUCT_CATEGORIES/Create
        public ActionResult Create()
        {
            ViewBag.ID_CATEGORY = new SelectList(db.CATEGORIES, "ID", "NAME");
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID_PRODUCT", "NAME");
            return View();
        }

        // POST: PRODUCT_CATEGORIES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_CATEGORY,ID_PRODUCT,DATE_CREATION,DATE_MODIFI")] PRODUCT_CATEGORIES pRODUCT_CATEGORIES)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCT_CATEGORIES.Add(pRODUCT_CATEGORIES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CATEGORY = new SelectList(db.CATEGORIES, "ID", "NAME", pRODUCT_CATEGORIES.ID_CATEGORIES);
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID_PRODUCT", "NAME", pRODUCT_CATEGORIES.ID_PRODUCT);
            return View(pRODUCT_CATEGORIES);
        }

        // GET: PRODUCT_CATEGORIES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_CATEGORIES pRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Find(id);
            if (pRODUCT_CATEGORIES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CATEGORY = new SelectList(db.CATEGORIES, "ID", "NAME", pRODUCT_CATEGORIES.ID_CATEGORIES);
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID_PRODUCT", "NAME", pRODUCT_CATEGORIES.ID_PRODUCT);
            return View(pRODUCT_CATEGORIES);
        }

        // POST: PRODUCT_CATEGORIES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_CATEGORY,ID_PRODUCT,DATE_CREATION,DATE_MODIFI")] PRODUCT_CATEGORIES pRODUCT_CATEGORIES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT_CATEGORIES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CATEGORY = new SelectList(db.CATEGORIES, "ID", "NAME", pRODUCT_CATEGORIES.ID_CATEGORIES);
            ViewBag.ID_PRODUCT = new SelectList(db.PRODUCTS, "ID_PRODUCT", "NAME", pRODUCT_CATEGORIES.ID_PRODUCT);
            return View(pRODUCT_CATEGORIES);
        }

        // GET: PRODUCT_CATEGORIES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_CATEGORIES pRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Find(id);
            if (pRODUCT_CATEGORIES == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_CATEGORIES);
        }

        // POST: PRODUCT_CATEGORIES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT_CATEGORIES pRODUCT_CATEGORIES = db.PRODUCT_CATEGORIES.Find(id);
            db.PRODUCT_CATEGORIES.Remove(pRODUCT_CATEGORIES);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
