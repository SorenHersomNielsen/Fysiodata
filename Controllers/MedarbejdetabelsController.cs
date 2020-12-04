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
    public class MedarbejdetabelsController : ApiController
    {
        private Medarbejder db = new Medarbejder();

        // GET: api/Medarbejdetabels
        public IQueryable<Medarbejdetabel> GetMedarbejdetabels()
        {
            return db.Medarbejdetabels;
        }

        // GET: api/Medarbejdetabels/5
        [ResponseType(typeof(Medarbejdetabel))]
        public IHttpActionResult GetMedarbejdetabel(int id)
        {
            Medarbejdetabel medarbejdetabel = db.Medarbejdetabels.Find(id);
            if (medarbejdetabel == null)
            {
                return NotFound();
            }

            return Ok(medarbejdetabel);
        }

        // PUT: api/Medarbejdetabels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedarbejdetabel(int id, Medarbejdetabel medarbejdetabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medarbejdetabel.MedarbejdeID)
            {
                return BadRequest();
            }

            db.Entry(medarbejdetabel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedarbejdetabelExists(id))
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

        // POST: api/Medarbejdetabels
        [ResponseType(typeof(Medarbejdetabel))]
        public IHttpActionResult PostMedarbejdetabel(Medarbejdetabel medarbejdetabel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medarbejdetabels.Add(medarbejdetabel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medarbejdetabel.MedarbejdeID }, medarbejdetabel);
        }

        // DELETE: api/Medarbejdetabels/5
        [ResponseType(typeof(Medarbejdetabel))]
        public IHttpActionResult DeleteMedarbejdetabel(int id)
        {
            Medarbejdetabel medarbejdetabel = db.Medarbejdetabels.Find(id);
            if (medarbejdetabel == null)
            {
                return NotFound();
            }

            db.Medarbejdetabels.Remove(medarbejdetabel);
            db.SaveChanges();

            return Ok(medarbejdetabel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedarbejdetabelExists(int id)
        {
            return db.Medarbejdetabels.Count(e => e.MedarbejdeID == id) > 0;
        }
    }
}