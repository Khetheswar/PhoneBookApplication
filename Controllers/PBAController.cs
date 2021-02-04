using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PBABusinessLayerLib;
using PBAEntitiesLayerLib;
using PBADataAccessLayerLib;

namespace PBAWebApi.Controllers
{
    public class PBAController : ApiController
    {
        public List<ContactCategory> Get()
        {
            PBABusinessLayer bll = new PBABusinessLayer();
            var lstCat = bll.GetAllcategoryNames();
            return lstCat;
        }
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage res = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Found");
            try
            {
                PBABusinessLayer bll = new PBABusinessLayer();
                var lstContacts = bll.GetAllContactsById(id);
                return res = Request.CreateResponse<List<Contact>>(lstContacts);
            }
            catch(Exception ex)
            {
                res = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return res;
        }
        public HttpResponseMessage Post([FromBody]ContactCategory cat)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Inserted");
            try
            {
                PBABusinessLayer bll = new PBABusinessLayer();
                bll.AddContactCategory(cat);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Record not found");
            }
            return errRes;
        }
        [Route("api/PBA/AddContact")]
        public HttpResponseMessage AddContact([FromBody]Contact contact)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Inserted");
            try
            {
                PBABusinessLayer bll = new PBABusinessLayer();
                bll.AddContact(contact);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Deleted");
            try
            {
                PBABusinessLayer bll = new PBABusinessLayer();
                bll.DeleteCategoryById(id);
            }
            catch(Exception ex)
            {
                errRes=Request.CreateErrorResponse(HttpStatusCode.NotFound,ex.Message);
            }
            return errRes;
        }
        [Route("api/PBA/DeleteContact")]
        public HttpResponseMessage DeleteContact(int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Deleted");
            try
            {
                PBABusinessLayer bll = new PBABusinessLayer();
                bll.DeleteContactById(id);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        public HttpResponseMessage Put([FromBody]ContactCategory cat,int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Updated");
            try
            {
                PBABusinessLayer bll = new PBABusinessLayer();
                bll.UpdateCategoryById(cat);
            }
            catch(Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
        [Route("api/PBA/UpdateContact")]
        public HttpResponseMessage UpdateContact([FromBody]Contact contact, int id)
        {
            HttpResponseMessage errRes = Request.CreateErrorResponse(HttpStatusCode.OK, "Record Updated");
            try
            {
                PBABusinessLayer bll = new PBABusinessLayer();
                bll.UpdateContactById(contact);
            }
            catch (Exception ex)
            {
                errRes = Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            return errRes;
        }
    }
}
