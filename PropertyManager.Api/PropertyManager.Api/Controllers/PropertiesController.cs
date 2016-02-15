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
using PropertyManager.Api.Domain;
using PropertyManager.Api.Infrastructure;
using AutoMapper;
using PropertyManager.Api.Models;

namespace PropertyManager.Api.Controllers
{
    public class PropertiesController : ApiController
    {
        private PropertyManagerDataContext db = new PropertyManagerDataContext();

        // GET: api/Properties
        public IEnumerable<PropertyModel> GetProperties()
        {
            var props = db.Properties;
            
            var models = Mapper.Map<IEnumerable<PropertyModel>>(props);

            return models;
            //return db.Properties;
        }

        //GET: api/Properties/Leases
        [Route("api/properties/{propertyId}/leases")]
        public IEnumerable<LeaseModel> GetLeasesForProperty(int propertyId)
        {
            var leases = db.Leases.Where(l => l.PropertyId == propertyId);

            return Mapper.Map<IEnumerable<LeaseModel>>(leases);
        }
        //GET: api/Properties/WorkOrders
        [Route("api/properties/{propertyId}/workOrders")]
        public IEnumerable<WorkOrderModel> GetWorkOrdersForProperty(int propertyId)
        {
            var workOrders = db.WorkOrders.Where(wo => wo.PropertyId == propertyId);

            return Mapper.Map<IEnumerable<WorkOrderModel>>(workOrders);
        }


        // GET: api/Properties/5
        [ResponseType(typeof(PropertyModel))]
        public IHttpActionResult GetProperty(int id)
        {
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PropertyModel>(property));
        }

        // PUT: api/Properties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProperty(int id, Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property.PropertyId)
            {
                return BadRequest();
            }

            db.Entry(property).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // POST: api/Properties
        [ResponseType(typeof(Property))]
        public IHttpActionResult PostProperty(Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Properties.Add(property);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = property.PropertyId }, property);
        }

        // DELETE: api/Properties/5
        [ResponseType(typeof(Property))]
        public IHttpActionResult DeleteProperty(int id)
        {
            Property property = db.Properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            db.Properties.Remove(property);
            db.SaveChanges();

            return Ok(property);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return db.Properties.Count(e => e.PropertyId == id) > 0;
        }
    }
}