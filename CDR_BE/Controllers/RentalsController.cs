﻿using System;
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
    public class RentalsController : ApiController
    {
        private CDREntities db = new CDREntities();

        // GET: api/Rentals
        public IQueryable<Rental> GetRental()
        {
            return db.Rental;
        }

        // GET: api/Rentals/5
        [ResponseType(typeof(Rental))]
        public IHttpActionResult GetRental(int id)
        {
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        // PUT: api/Rentals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRental(int id, Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rental.RentalId)
            {
                return BadRequest();
            }

            db.Entry(rental).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(id))
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

        // POST: api/Rentals
        [ResponseType(typeof(Rental))]
        public IHttpActionResult PostRental(Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rental.Add(rental);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rental.RentalId }, rental);
        }

        // DELETE: api/Rentals/5
        [ResponseType(typeof(Rental))]
        public IHttpActionResult DeleteRental(int id)
        {
            Rental rental = db.Rental.Find(id);
            if (rental == null)
            {
                return NotFound();
            }

            db.Rental.Remove(rental);
            db.SaveChanges();

            return Ok(rental);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentalExists(int id)
        {
            return db.Rental.Count(e => e.RentalId == id) > 0;
        }
    }
}