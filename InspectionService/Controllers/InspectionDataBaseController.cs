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
    public class InspectionDataBaseController : ApiController
    {
        private InspectionServiceContext db = new InspectionServiceContext();

        // GET api/InspectionDataBase
        public IEnumerable<InspectionDataBaseModel> GetInspectionDataBaseModels()
        {
            return db.InspectionDataBaseModels.AsEnumerable();
        }

        // GET api/InspectionDataBase/5
        public List<InspectionDataBaseModel> GetInspectionDataBaseModel(string id)
        {
            string[] parametersArray = id.Split('|');
            string parameterType = "";
            List<InspectionDataBaseModel> resultList = new List<InspectionDataBaseModel>();
            if (parametersArray.Length > 0)
            {
                parameterType = parametersArray[0];
                if (parameterType.Equals("unchecked"))
                {
                    IEnumerable<InspectionDataBaseModel> inspectionsIEnum = from i in db.InspectionDataBaseModels
                                                                            where i.IsAccepted == null
                                                                            orderby i.InspectionId
                                                                            select i;
                    if (inspectionsIEnum == null || inspectionsIEnum.Count<InspectionDataBaseModel>() == 0)
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                    }
                    resultList = inspectionsIEnum.ToList<InspectionDataBaseModel>();
                }
                if (parameterType.Equals("accepted"))
                {
                    IEnumerable<InspectionDataBaseModel> inspectionsIEnum = from i in db.InspectionDataBaseModels
                                                                            where i.IsAccepted.Equals("accepted")
                                                                            orderby i.InspectionId
                                                                            select i;
                    if (inspectionsIEnum == null || inspectionsIEnum.Count<InspectionDataBaseModel>() == 0)
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                    }
                    resultList = inspectionsIEnum.ToList<InspectionDataBaseModel>();
                }
                if (parameterType.Equals("declined"))
                {
                    IEnumerable<InspectionDataBaseModel> inspectionsIEnum = from i in db.InspectionDataBaseModels
                                                                            where i.IsAccepted.Equals("declined")
                                                                            orderby i.InspectionId
                                                                            select i;
                    if (inspectionsIEnum == null || inspectionsIEnum.Count<InspectionDataBaseModel>() == 0)
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                    }
                    resultList = inspectionsIEnum.ToList<InspectionDataBaseModel>();
                }
                if (parameterType.Equals("single") && parametersArray.Length > 1)
                {
                    InspectionDataBaseModel inspectiondatabasemodel = db.InspectionDataBaseModels.Find(parametersArray[1]); //get single inspection by its id
                    if (inspectiondatabasemodel == null)
                    {
                        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                    }
                    resultList.Add(inspectiondatabasemodel);
                }
            }

            return resultList;
        }

        // PUT api/InspectionDataBase/5
        public HttpResponseMessage PutInspectionDataBaseModel(string id, InspectionDataBaseModel inspectiondatabasemodel)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != inspectiondatabasemodel.InspectionId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(inspectiondatabasemodel).State = EntityState.Modified;

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

        // POST api/InspectionDataBase
        public HttpResponseMessage PostInspectionDataBaseModel(InspectionDataBaseModel inspectiondatabasemodel)
        {
            if (ModelState.IsValid)
            {
                //update an existing one or add a new one
                InspectionDataBaseModel ins = db.InspectionDataBaseModels.Find(inspectiondatabasemodel.InspectionId);
                if (ins != null)
                {
                    db.InspectionDataBaseModels.Remove(ins);
                }
                db.InspectionDataBaseModels.Add(inspectiondatabasemodel);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, inspectiondatabasemodel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = inspectiondatabasemodel.InspectionId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/InspectionDataBase/5
        public HttpResponseMessage DeleteInspectionDataBaseModel(string id)
        {
            InspectionDataBaseModel inspectiondatabasemodel = db.InspectionDataBaseModels.Find(id);
            if (inspectiondatabasemodel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.InspectionDataBaseModels.Remove(inspectiondatabasemodel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, inspectiondatabasemodel);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}