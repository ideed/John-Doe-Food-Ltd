﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using John_Doe_Food_Ltd.Models;

namespace John_Doe_Food_Ltd.API
{
    public class OrdersController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/Orders
        public IQueryable<OrderDTO> GetOrders()
        {
            var order = from o in db.Orders
                        select new OrderDTO()
                        {
                            OrderId = o.OrderId,
                            DateOrdered = o.DateOrdered,
                            Product = o.Product.Select(p=>new CatalougeDTO() { 
                                FoodId = p.FoodId,
                                FoodName = p.FoodName,
                                FoodType = p.FoodType,
                                CommericalGood = p.CommericalGood,
                                Suppliers = p.Supplier.Select(s => new SupplierDTO()
                                {
                                    SupplierId = s.SupplierId,
                                    SupplierName = s.SupplierName,
                                    SupplierType = s.SupplierType
                                }).ToList()
                            }).ToList(),
                            Customer = o.Customer.Select(c => new CustomerDTO() { 
                                CustomerId = c.CustomerId,
                                CustomerName = c.CustomerName,
                                Commercial = c.Commercial,
                                TelephoneNo = c.TelephoneNo,
                                Email = c.Email,
                                Address = c.Address
                            }).ToList()
                        };
            return order;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrderDTO))]
        public async Task<IHttpActionResult> GetOrder(int id)
        {
            Order o = await db.Orders.FindAsync(id);
            if (o == null)
            {
                return NotFound();
            }
            OrderDTO order = new OrderDTO
            {
                OrderId = o.OrderId,
                DateOrdered = o.DateOrdered,
                Product = o.Product.Select(p => new CatalougeDTO()
                {
                    FoodId = p.FoodId,
                    FoodName = p.FoodName,
                    FoodType = p.FoodType,
                    CommericalGood = p.CommericalGood,
                    Suppliers = p.Supplier.Select(s => new SupplierDTO()
                    {
                        SupplierId = s.SupplierId,
                        SupplierName = s.SupplierName,
                        SupplierType = s.SupplierType
                    }).ToList()
                }).ToList(),
                Customer = o.Customer.Select(c => new CustomerDTO()
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Commercial = c.Commercial,
                    TelephoneNo = c.TelephoneNo,
                    Email = c.Email,
                    Address = c.Address
                }).ToList()
            };

            return Ok(order);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrder(int id, Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.OrderId)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Orders
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(order);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Order))]
        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            await db.SaveChangesAsync();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Count(e => e.OrderId == id) > 0;
        }
    }
}