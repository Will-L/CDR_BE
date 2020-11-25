using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CDR_BE.Models;

namespace CDR_BE.Controllers
{
    public class RentalItemsController : ApiController
    {
        private CDREntities db = new CDREntities();

        // GET: api/RentalItems
        public IQueryable<RentalItem> GetRentalItem()
        {
            return db.RentalItem;
        }

        /// <summary>
        /// The following method gets a single RentalItem ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Rental Item</returns>
        /// 
        // GET: api/RentalItems/5
        [ResponseType(typeof(RentalItem))]
        public IHttpActionResult GetRentalItem(int id)
        {
            RentalItem rentalItem = db.RentalItem.Find(id);
            if (rentalItem == null)
            {
                return NotFound();
            }

            return Ok(rentalItem);
        }

        [HttpGet]
        [Route("api/RentalItemsById/{id}")]
        [ResponseType(typeof(RentalItem))]
        public IQueryable<RentalItem> GetRentalItemById(int id)
        {
            return db.RentalItem.Where(r => r.RentalId == id);
            
        }   

        /// <summary>
        /// This method will update an exisitng rentalItem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rentalItem"></param>
        /// <returns></returns>
        // PUT: api/RentalItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRentalItem(int id, RentalItem rentalItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rentalItem.RentalItemId)
            {
                return BadRequest();
            }

            db.Entry(rentalItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalItemExists(id))
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

        /// <summary>
        /// This method will add a new rental item 
        /// </summary>
        /// <param name="rentalItem"></param>
        /// <returns></returns>

        // POST: api/RentalItems
        [ResponseType(typeof(RentalItem))]
        public IHttpActionResult PostRentalItem(RentalItem rentalItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RentalItem.Add(rentalItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rentalItem.RentalItemId }, rentalItem);
        }

        /// <summary>
        /// This method will delete an existing rentalItem
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE: api/RentalItems/5
        [ResponseType(typeof(RentalItem))]
        public IHttpActionResult DeleteRentalItem(int id)
        {
            RentalItem rentalItem = db.RentalItem.Find(id);
            if (rentalItem == null)
            {
                return NotFound();
            }

            db.RentalItem.Remove(rentalItem);
            db.SaveChanges();

            return Ok(rentalItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentalItemExists(int id)
        {
            return db.RentalItem.Count(e => e.RentalItemId == id) > 0;
        }
    }
}