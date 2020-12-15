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
    public class OrdersController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            return View(await db.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            //Return View(Catalouge and Customer)
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.Order = db.Orders.Include(o => o.Customer).Include(o => o.Product).First(o => o.OrderId == id); ;
            orderViewModel.AllCustomers = db.Customers.Select(c => new SelectListItem
            {
                Text = c.CustomerName,
                Value = c.CustomerId.ToString()
            }
            );
            orderViewModel.AllCatalouges = db.Catalouges.Select(c => new SelectListItem
            {
                Text = c.FoodName,
                Value = c.FoodId.ToString()
            }
            );
            orderViewModel.SelectedCustomers = orderViewModel.Order.Customer.Select(c => c.CustomerId).ToList();
            orderViewModel.SelectedCatalouges = orderViewModel.Order.Product.Select(p => p.FoodId).ToList();
            return View(orderViewModel);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrderId,DateOrdered")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.Order = db.Orders.Include(o => o.Customer).Include(o => o.Product).First(o => o.OrderId == id); ;
            orderViewModel.AllCustomers = db.Customers.Select(c => new SelectListItem
            {
                Text = c.CustomerName,
                Value = c.CustomerId.ToString()
            }
            );
            orderViewModel.AllCatalouges = db.Catalouges.Select(c => new SelectListItem
            {
                Text = c.FoodName,
                Value = c.FoodId.ToString()
            }
            );
            orderViewModel.SelectedCustomers = orderViewModel.Order.Customer.Select(c => c.CustomerId).ToList();
            orderViewModel.SelectedCatalouges = orderViewModel.Order.Product.Select(p => p.FoodId).ToList();
            return View(orderViewModel);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                Order order = db.Orders.Include(o => o.Customer).Include(o => o.Product).First(o => o.OrderId == orderViewModel.Order.OrderId);
                HashSet<int> selectedCustomers = new HashSet<int>(orderViewModel.SelectedCustomers);
                HashSet<int> selectedCatalouges = new HashSet<int>(orderViewModel.SelectedCatalouges);
                foreach(Customer c in db.Customers)
                {
                    if(!selectedCustomers.Contains(c.CustomerId))
                    {
                        order.Customer.Remove(c);
                    }
                    else
                    {
                        order.Customer.Add(c);
                    }
                }
                foreach(Catalouge c in db.Catalouges)
                {
                    if(!selectedCatalouges.Contains(c.FoodId))
                    {
                        order.Product.Remove(c);
                    }
                    else
                    {
                        order.Product.Add(c);
                    }
                }
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderViewModel);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            db.Orders.Remove(order);
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

        //GET: Orders/Search

        public ActionResult Search()
        {
            return View();
        }

    }
}
