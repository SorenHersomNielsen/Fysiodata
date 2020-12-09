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
    public class IndstillingtabelsController : ApiController
    {
        private Indstilling db = new Indstilling();

        // GET: api/Indstillingtabels
        public IQueryable<Indstillingtabel> GetIndstillingtabels()
        {
            return db.Indstillingtabels;
        }

        // GET: api/Indstillingtabels/5
        [ResponseType(typeof(Indstillingtabel))]
        public IHttpActionResult GetIndstillingtabel(int id)
        {
            Indstillingtabel indstillingtabel = db.Indstillingtabels.Find(id);
            if (indstillingtabel == null)
            {
                return NotFound();
            }

            return Ok(indstillingtabel);
        }

        // PUT: api/Indstillingtabels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIndstillingtabel(int id, Indstillingtabel indstillingtabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != indstillingtabel.IndstillingID)
            {
                return BadRequest();
            }

            db.Entry(indstillingtabel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndstillingtabelExists(id))
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

        // POST: api/Indstillingtabels
        [ResponseType(typeof(Indstillingtabel))]
        public IHttpActionResult PostIndstillingtabel(Indstillingtabel indstillingtabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Indstillingtabels.Add(indstillingtabel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = indstillingtabel.IndstillingID }, indstillingtabel);
        }

        // DELETE: api/Indstillingtabels/5
        [ResponseType(typeof(Indstillingtabel))]
        public IHttpActionResult DeleteIndstillingtabel(int id)
        {
            Indstillingtabel indstillingtabel = db.Indstillingtabels.Find(id);
            if (indstillingtabel == null)
            {
                return NotFound();
            }

            db.Indstillingtabels.Remove(indstillingtabel);
            db.SaveChanges();

            return Ok(indstillingtabel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IndstillingtabelExists(int id)
        {
            return db.Indstillingtabels.Count(e => e.IndstillingID == id) > 0;
        }
    }
}