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
using FysiodataAPI;

namespace FysiodataAPI.Controllers
{
    public class PatientstabelsController : ApiController
    {
        private Patient db = new Patient();

        // GET: api/Patientstabels
        public IQueryable<Patientstabel> GetPatientstabels()
        {
            return db.Patientstabels;
        }

        // GET: api/Patientstabels/5
        [ResponseType(typeof(Patientstabel))]
        public IHttpActionResult GetPatientstabel(long id)
        {
            Patientstabel patientstabel = db.Patientstabels.Find(id);
            if (patientstabel == null)
            {
                return NotFound();
            }

            return Ok(patientstabel);
        }

        // PUT: api/Patientstabels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatientstabel(long id, Patientstabel patientstabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patientstabel.Cprnr)
            {
                return BadRequest();
            }

            db.Entry(patientstabel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientstabelExists(id))
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

        // POST: api/Patientstabels
        [ResponseType(typeof(Patientstabel))]
        public IHttpActionResult PostPatientstabel(Patientstabel patientstabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Patientstabels.Add(patientstabel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PatientstabelExists(patientstabel.Cprnr))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patientstabel.Cprnr }, patientstabel);
        }

        // DELETE: api/Patientstabels/5
        [ResponseType(typeof(Patientstabel))]
        public IHttpActionResult DeletePatientstabel(long id)
        {
            Patientstabel patientstabel = db.Patientstabels.Find(id);
            if (patientstabel == null)
            {
                return NotFound();
            }

            db.Patientstabels.Remove(patientstabel);
            db.SaveChanges();

            return Ok(patientstabel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatientstabelExists(long id)
        {
            return db.Patientstabels.Count(e => e.Cprnr == id) > 0;
        }
    }
}