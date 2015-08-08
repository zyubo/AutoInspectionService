using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using InspectionService.Models;

namespace InspectionService.Controllers
{
    public class InspectionCustomerController : ApiController
    {
        private InspectionServiceContext db = new InspectionServiceContext();

        // GET api/InspectionCustomer
        public IEnumerable<InspectionCustomerModel> GetInspectionCustomerModels()
        {
            return db.InspectionCustomerModels.AsEnumerable();
        }

        // GET api/InspectionCustomer/5
        public InspectionCustomerModel GetInspectionCustomerModel(string id)
        {
            InspectionCustomerModel inspectioncustomermodel = db.InspectionCustomerModels.Find(id);
            if (inspectioncustomermodel == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return inspectioncustomermodel;
        }

        // PUT api/InspectionCustomer/5
        public HttpResponseMessage PutInspectionCustomerModel(string id, InspectionCustomerModel inspectioncustomermodel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != inspectioncustomermodel.InspectionCustomerId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(inspectioncustomermodel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/InspectionCustomer
        public HttpResponseMessage PostInspectionCustomerModel(IEnumerable<InspectionCustomerModel> inspectioncustomermodelIEnum)
        {
            if (ModelState.IsValid)
            {
                foreach (InspectionCustomerModel inspectionCustomerModel in inspectioncustomermodelIEnum)
                {
                    //inspectionCustomerModel.InspectionCustomerId = Guid.NewGuid().ToString();
                    //db.InspectionCustomerModels.Add(inspectionCustomerModel);
                    //InspectionDataBaseModel inspectionDataBaseModel = db.InspectionDataBaseModels.Find(inspectionCustomerModel.InspectionId);
                    //inspectionDataBaseModel.IsAccepted = inspectionCustomerModel.IsAccepted;
                    //db.SaveChanges();
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, inspectioncustomermodelIEnum);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = inspectioncustomermodelIEnum }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/InspectionCustomer/5
        public HttpResponseMessage DeleteInspectionCustomerModel(string id)
        {
            InspectionCustomerModel inspectioncustomermodel = db.InspectionCustomerModels.Find(id);
            if (inspectioncustomermodel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.InspectionCustomerModels.Remove(inspectioncustomermodel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, inspectioncustomermodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}