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
    public class MaskinetabelsController : ApiController
    {
        private Maskine db = new Maskine();

        // GET: api/Maskinetabels
        public IQueryable<Maskinetabel> GetMaskinetabels()
        {
            return db.Maskinetabels;
        }

        // GET: api/Maskinetabels/5
        [ResponseType(typeof(Maskinetabel))]
        public IHttpActionResult GetMaskinetabel(int id)
        {
            Maskinetabel maskinetabel = db.Maskinetabels.Find(id);
            if (maskinetabel == null)
            {
                return NotFound();
            }

            return Ok(maskinetabel);
        }

        // PUT: api/Maskinetabels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaskinetabel(int id, Maskinetabel maskinetabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != maskinetabel.MaskineID)
            {
                return BadRequest();
            }

            db.Entry(maskinetabel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaskinetabelExists(id))
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

        // POST: api/Maskinetabels
        [ResponseType(typeof(Maskinetabel))]
        public IHttpActionResult PostMaskinetabel(Maskinetabel maskinetabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Maskinetabels.Add(maskinetabel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = maskinetabel.MaskineID }, maskinetabel);
        }

        // DELETE: api/Maskinetabels/5
        [ResponseType(typeof(Maskinetabel))]
        public IHttpActionResult DeleteMaskinetabel(int id)
        {
            Maskinetabel maskinetabel = db.Maskinetabels.Find(id);
            if (maskinetabel == null)
            {
                return NotFound();
            }

            db.Maskinetabels.Remove(maskinetabel);
            db.SaveChanges();

            return Ok(maskinetabel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaskinetabelExists(int id)
        {
            return db.Maskinetabels.Count(e => e.MaskineID == id) > 0;
        }
    }
}