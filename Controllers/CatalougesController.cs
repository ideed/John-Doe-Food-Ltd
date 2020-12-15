using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using John_Doe_Food_Ltd.Models;

namespace John_Doe_Food_Ltd.Controllers
{
    public class CatalougesController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Catalouges
        public async Task<ActionResult> Index()
        {
            return View(await db.Catalouges.ToListAsync());
        }

        // GET: Catalouges/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalouge catalouge = await db.Catalouges.FindAsync(id);
            if (catalouge == null)
            {
                return HttpNotFound();
            }
            //return View(supplier);
            CatalougeViewModel catalougeViewModel = new CatalougeViewModel();
            catalougeViewModel.Catalouge = db.Catalouges.Include(c => c.Supplier).First(c => c.FoodId == id); ;
            catalougeViewModel.AllSuppliers = db.Suppliers.Select(s => new SelectListItem
            {
                Text = s.SupplierName,
                Value = s.SupplierId.ToString()
            }
            );
            catalougeViewModel.SelectedSuppliers = catalougeViewModel.Catalouge.Supplier.Select(s => s.SupplierId).ToList();
            return View(catalougeViewModel);
        }

        // GET: Catalouges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Catalouges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FoodId,FoodName,FoodType,CommericalGood")] Catalouge catalouge)
        {
            if (ModelState.IsValid)
            {
                db.Catalouges.Add(catalouge);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(catalouge);
        }

        // GET: Catalouges/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalouge catalouge = await db.Catalouges.FindAsync(id);
            if (catalouge == null)
            {
                return HttpNotFound();
            }
            CatalougeViewModel catalougeViewModel = new CatalougeViewModel();
            catalougeViewModel.Catalouge = db.Catalouges.Include(c => c.Supplier).First(c => c.FoodId == id);
            catalougeViewModel.AllSuppliers = db.Suppliers.Select(s => new SelectListItem
            {
                Text = s.SupplierName,
                Value = s.SupplierId.ToString()
            }
            );
            catalougeViewModel.SelectedSuppliers = catalouge.Supplier.Select(s => s.SupplierId).ToList();
            return View(catalougeViewModel);
        }

        // POST: Catalouges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CatalougeViewModel catalougeViewModel)
        {
            if(ModelState.IsValid)
            {
                Catalouge catalouge = db.Catalouges.Include(c => c.Supplier).First(c => c.FoodId == catalougeViewModel.Catalouge.FoodId);
                HashSet<int> selectedSuppliers = new HashSet<int>(catalougeViewModel.SelectedSuppliers);
                foreach(Supplier s in db.Suppliers)
                {
                    if(!selectedSuppliers.Contains(s.SupplierId))
                    {
                        catalouge.Supplier.Remove(s);
                    }
                    else
                    {
                        catalouge.Supplier.Add(s);
                    }
                }
                db.Entry(catalouge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catalougeViewModel);
        }

        // GET: Catalouges/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Catalouge catalouge = await db.Catalouges.FindAsync(id);
            if (catalouge == null)
            {
                return HttpNotFound();
            }
            return View(catalouge);
        }

        // POST: Catalouges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Catalouge catalouge = await db.Catalouges.FindAsync(id);
            db.Catalouges.Remove(catalouge);
            await db.SaveChangesAsync();
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

        //GET: Catalouge/Search
        public ActionResult Search()
        {
            return View();
        }
    }
}
