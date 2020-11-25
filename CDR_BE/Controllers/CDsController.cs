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
    public class CDsController : ApiController
    {
        private CDREntities db = new CDREntities();

        // GET: api/CDs
        public IQueryable<CD> GetCD()
        {
            return db.CD;
        }

        // GET: api/CDs/5
        [ResponseType(typeof(CD))]
        public IHttpActionResult GetCD(int id)
        {
            CD cD = db.CD.Find(id);
            if (cD == null)
            {
                return NotFound();
            }

            return Ok(cD);
        }

        // PUT: api/CDs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCD(int id, CD cD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cD.CDId)
            {
                return BadRequest();
            }

            db.Entry(cD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CDExists(id))
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

        // POST: api/CDs
        [ResponseType(typeof(CD))]
        public IHttpActionResult PostCD(CD cD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CD.Add(cD);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cD.CDId }, cD);
        }

        // DELETE: api/CDs/5
        [ResponseType(typeof(CD))]
        public IHttpActionResult DeleteCD(int id)
        {
            CD cD = db.CD.Find(id);
            if (cD == null)
            {
                return NotFound();
            }

            db.CD.Remove(cD);
            db.SaveChanges();

            return Ok(cD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CDExists(int id)
        {
            return db.CD.Count(e => e.CDId == id) > 0;
        }
    }
}