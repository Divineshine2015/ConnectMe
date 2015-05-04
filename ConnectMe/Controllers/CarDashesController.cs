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
using ConnectMe.Models;

namespace ConnectMe.Controllers
{
    public class CarDashesController : ApiController
    {
        private ConnectMeContext db = new ConnectMeContext();

        // GET: api/CarDashes
        public IQueryable<CarDash> GetCarDashes()
        {
            return db.CarDashes;
        }

        // GET: api/CarDashes/5
        [ResponseType(typeof(CarDash))]
        public IHttpActionResult GetCarDash(int id)
        {
            CarDash carDash = db.CarDashes.Find(id);
            if (carDash == null)
            {
                return NotFound();
            }

            return Ok(carDash);
        }

        // PUT: api/CarDashes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarDash(int id, CarDash carDash)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carDash.Id)
            {
                return BadRequest();
            }

            db.Entry(carDash).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarDashExists(id))
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

        // POST: api/CarDashes
        [ResponseType(typeof(CarDash))]
        public IHttpActionResult PostCarDash(CarDash carDash)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarDashes.Add(carDash);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carDash.Id }, carDash);
        }

        // DELETE: api/CarDashes/5
        [ResponseType(typeof(CarDash))]
        public IHttpActionResult DeleteCarDash(int id)
        {
            CarDash carDash = db.CarDashes.Find(id);
            if (carDash == null)
            {
                return NotFound();
            }

            db.CarDashes.Remove(carDash);
            db.SaveChanges();

            return Ok(carDash);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarDashExists(int id)
        {
            return db.CarDashes.Count(e => e.Id == id) > 0;
        }
    }
}