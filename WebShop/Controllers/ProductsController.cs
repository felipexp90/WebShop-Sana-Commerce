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
    public class ProductsController : Controller
    {
        private WEBSHOPEntities db = new WEBSHOPEntities();

        // GET: Products
        public ActionResult Index(string OptionStorage)
        {
            if (OptionStorage == "database")
            {
                return View(db.PRODUCTS.ToList());
            }
            else
            {
                List<PRODUCTS> ListPRODUCTS = new List<PRODUCTS>();
                ListPRODUCTS = (List<PRODUCTS>)Session["PRODUCT"];
                if (ListPRODUCTS != null)
                {
                    return View(ListPRODUCTS.ToList());
                }
                else
                {
                    ListPRODUCTS = new List<PRODUCTS>();
                    PRODUCTS _PRODUCTS = new PRODUCTS();
                    ListPRODUCTS.Add(_PRODUCTS);
                    return View(ListPRODUCTS.ToList());
                }
            }
        }

       
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTS pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRODUCT,NAME,DESCRIPTION,PRICE,AMOUNTS,ACTIVE,DATE_CREATION,DATE_MODIFI")] PRODUCTS pRODUCT)
        {
            var keys = Request.Form.AllKeys;
            var OptionStorage = Request.Form.Get("SelectedStorage");
            pRODUCT.ACTIVE = true;
            pRODUCT.DATE_CREATION = DateTime.Now;
            pRODUCT.DATE_MODIFI = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (OptionStorage == "database")
                {
                    db.PRODUCTS.Add(pRODUCT);
                    db.SaveChanges();
                }
                else
                {
                    List<PRODUCTS> ListPRODUCTS = new List<PRODUCTS>();
                    if ((List<PRODUCTS>)Session["PRODUCT"] != null)
                    {
                        ListPRODUCTS = (List<PRODUCTS>)Session["PRODUCT"];
                    }

                    ListPRODUCTS.Add(pRODUCT);
                    Session["PRODUCT"] = ListPRODUCTS;
                }
                return RedirectToAction("Index");
            }
            return View(pRODUCT);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTS pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRODUCT,NAME,DESCRIPTION,PRICE,AMOUNTS,ACTIVE,DATE_CREATION,DATE_MODIFI")] PRODUCTS pRODUCT)
        {
            if (ModelState.IsValid)
            {
                pRODUCT.DATE_MODIFI = DateTime.Now;
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRODUCT);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCTS pRODUCT = db.PRODUCTS.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCTS pRODUCT = db.PRODUCTS.Find(id);
            db.PRODUCTS.Remove(pRODUCT);
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
