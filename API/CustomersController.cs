using System;
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
    public class CustomersController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/Customers
        public IQueryable<CustomerDTO> GetCustomers()
        {
            var customer = from c in db.Customers
                           select new CustomerDTO()
                           {
                                CustomerId = c.CustomerId,
                                CustomerName = c.CustomerName,
                                Commercial = c.Commercial,
                                TelephoneNo = c.TelephoneNo,
                                Email = c.Email,
                                Address = c.Address
                            };
            return customer;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(CustomerDTO))]
        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            Customer c = await db.Customers.FindAsync(id);
            if (c == null)
            {
                return NotFound();
            }

            CustomerDTO customer = new CustomerDTO
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                Commercial = c.Commercial,
                TelephoneNo = c.TelephoneNo,
                Email = c.Email,
                Address = c.Address
            };

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            db.Entry(customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> DeleteCustomer(int id)
        {
            Customer customer = await db.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customer);
            await db.SaveChangesAsync();

            return Ok(customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customers.Count(e => e.CustomerId == id) > 0;
        }
    }
}