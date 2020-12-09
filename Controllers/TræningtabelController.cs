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
    public class TræningtabelController : ApiController
    {
        private Træning db = new Træning();

        // GET: api/Træningtabel
        public IQueryable<Træningtabel> GetTræningtabel()
        {
            return db.Træningtabel;
        }

        // GET: api/Træningtabel/5
        [ResponseType(typeof(Træningtabel))]
        public IHttpActionResult GetTræningtabel(int id)
        {
            Træningtabel træningtabel = db.Træningtabel.Find(id);
            if (træningtabel == null)
            {
                return NotFound();
            }

            return Ok(træningtabel);
        }

        // PUT: api/Træningtabel/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTræningtabel(int id, Træningtabel træningtabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != træningtabel.dato)
            {
                return BadRequest();
            }

            db.Entry(træningtabel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TræningtabelExists(id))
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

        // POST: api/Træningtabel
        [ResponseType(typeof(Træningtabel))]
        public IHttpActionResult PostTræningtabel(Træningtabel træningtabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Træningtabel.Add(træningtabel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TræningtabelExists(træningtabel.dato))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = træningtabel.dato }, træningtabel);
        }

        // DELETE: api/Træningtabel/5
        [ResponseType(typeof(Træningtabel))]
        public IHttpActionResult DeleteTræningtabel(int id)
        {
            Træningtabel træningtabel = db.Træningtabel.Find(id);
            if (træningtabel == null)
            {
                return NotFound();
            }

            db.Træningtabel.Remove(træningtabel);
            db.SaveChanges();

            return Ok(træningtabel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TræningtabelExists(int id)
        {
            return db.Træningtabel.Count(e => e.dato == id) > 0;
        }
    }
}