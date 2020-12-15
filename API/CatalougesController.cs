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
    public class CatalougesController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/Catalouges
        public IQueryable<CatalougeDTO> GetCatalouges()
        {
            var catalouge = from c in db.Catalouges
                            select new CatalougeDTO()
                            {
                                FoodId = c.FoodId,
                                FoodName = c.FoodName,
                                FoodType = c.FoodType,
                                CommericalGood = c.CommericalGood,
                                Suppliers = c.Supplier.Select(s=>new SupplierDTO() { 
                                    SupplierId = s.SupplierId,
                                    SupplierName = s.SupplierName,
                                    SupplierType = s.SupplierType
                                }).ToList()
                            };
            
            return catalouge;
        }

        // GET: api/Catalouges/5
        [ResponseType(typeof(CatalougeDTO))]
        public async Task<IHttpActionResult> GetCatalouge(int id)
        {
            Catalouge c = await db.Catalouges.FindAsync(id);
            if (c == null)
            {
                return NotFound();
            }
            CatalougeDTO catalouge = new CatalougeDTO
            {
                FoodId = c.FoodId,
                FoodName = c.FoodName,
                FoodType = c.FoodType,
                CommericalGood = c.CommericalGood,
                Suppliers = c.Supplier.Select(s => new SupplierDTO()
                {
                    SupplierId = s.SupplierId,
                    SupplierName = s.SupplierName,
                    SupplierType = s.SupplierType
                }).ToList()
            };

            return Ok(catalouge);
        }

        // PUT: api/Catalouges/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCatalouge(int id, Catalouge catalouge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catalouge.FoodId)
            {
                return BadRequest();
            }

            db.Entry(catalouge).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalougeExists(id))
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

        // POST: api/Catalouges
        [ResponseType(typeof(Catalouge))]
        public async Task<IHttpActionResult> PostCatalouge(Catalouge catalouge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Catalouges.Add(catalouge);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = catalouge.FoodId }, catalouge);
        }

        // DELETE: api/Catalouges/5
        [ResponseType(typeof(Catalouge))]
        public async Task<IHttpActionResult> DeleteCatalouge(int id)
        {
            Catalouge catalouge = await db.Catalouges.FindAsync(id);
            if (catalouge == null)
            {
                return NotFound();
            }

            db.Catalouges.Remove(catalouge);
            await db.SaveChangesAsync();

            return Ok(catalouge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatalougeExists(int id)
        {
            return db.Catalouges.Count(e => e.FoodId == id) > 0;
        }
    }
}