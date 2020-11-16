using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using John_Doe_Food_Ltd.Models;

namespace John_Doe_Food_Ltd.Controllers
{
    public class CatalougeController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Catalouge
        public ActionResult Index()
        {
            return View(db.Catalouges.ToList());
        }

        // GET: Catalouge/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalouge catalouge = db.Catalouges.Find(id);
            if (catalouge == null)
            {
                return HttpNotFound();
            }
            return View(catalouge);
        }

        // GET: Catalouge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalouge/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodId,FoodName,FoodType,CommericalGood")] Catalouge catalouge)
        {
            if (ModelState.IsValid)
            {
                db.Catalouges.Add(catalouge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catalouge);
        }

        // GET: Catalouge/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalouge catalouge = db.Catalouges.Find(id);
            if (catalouge == null)
            {
                return HttpNotFound();
            }
            return View(catalouge);
        }

        // POST: Catalouge/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodId,FoodName,FoodType,CommericalGood")] Catalouge catalouge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catalouge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalouge);
        }

        // GET: Catalouge/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalouge catalouge = db.Catalouges.Find(id);
            if (catalouge == null)
            {
                return HttpNotFound();
            }
            return View(catalouge);
        }

        // POST: Catalouge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Catalouge catalouge = db.Catalouges.Find(id);
            db.Catalouges.Remove(catalouge);
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
