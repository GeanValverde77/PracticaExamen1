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
using PracticaExamen.Models;

namespace PracticaExamen.Controllers
{
    public class ValverdesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Valverdes
        [Authorize]
        public IQueryable<Valverde> GetValverdes()
        {
            return db.Valverdes;
        }

        // GET: api/Valverdes/5
        [Authorize]
        [ResponseType(typeof(Valverde))]
        public IHttpActionResult GetValverde(int id)
        {
            Valverde valverde = db.Valverdes.Find(id);
            if (valverde == null)
            {
                return NotFound();
            }

            return Ok(valverde);
        }

        // PUT: api/Valverdes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutValverde(int id, Valverde valverde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != valverde.ValverdeID)
            {
                return BadRequest();
            }

            db.Entry(valverde).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValverdeExists(id))
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

        // POST: api/Valverdes
        [Authorize]
        [ResponseType(typeof(Valverde))]
        public IHttpActionResult PostValverde(Valverde valverde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Valverdes.Add(valverde);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = valverde.ValverdeID }, valverde);
        }

        // DELETE: api/Valverdes/5
        [Authorize]
        [ResponseType(typeof(Valverde))]
        public IHttpActionResult DeleteValverde(int id)
        {
            Valverde valverde = db.Valverdes.Find(id);
            if (valverde == null)
            {
                return NotFound();
            }

            db.Valverdes.Remove(valverde);
            db.SaveChanges();

            return Ok(valverde);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public IHttpActionResult DeleteValverde(Valverde esperado, object valverdeID)
        {
            throw new NotImplementedException();
        }

        private bool ValverdeExists(int id)
        {
            return db.Valverdes.Count(e => e.ValverdeID == id) > 0;
        }
    }
}