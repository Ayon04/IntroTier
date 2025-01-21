using BLL.DTOs;
using BLL.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTier.Controllers
{
    public class ContactController : ApiController
    {
        [HttpPost]
        [Route("api/contacts/create")]
        public HttpResponseMessage Create(ContactDTO c)
        {
            ContactService.Create(c);
            return Request.CreateResponse(HttpStatusCode.OK, "Contact created successfully.");
        }

        [HttpGet]
        [Route("api/contacts/all")]
        public HttpResponseMessage GetAll()
        {
            var data = ContactService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/contacts/name/{name}")]
        public HttpResponseMessage Get(string name)
        {
            var data = ContactService.Get(name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/contacts/category/{category}")]
        public HttpResponseMessage GetByCategory(string category)
        {
            var data = ContactService.GetByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }



        [HttpPut]
        [Route("api/contacts/update/{id}")]
        public HttpResponseMessage Update(int id, ContactDTO c)
        {
            var newdata = ContactService.GetById(id); 

            if (newdata == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Contact not found.");
            }

            newdata.Name = c.Name;
            newdata.Phone = c.Phone;
            newdata.Email = c.Email;
            newdata.Address = c.Address;
            newdata.Note = c.Note;
            newdata.Category = c.Category;

            ContactService.Update(newdata);

            return Request.CreateResponse(HttpStatusCode.OK, "Contact updated successfully.");
        }

        [HttpDelete]
        [Route("api/contacts/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            ContactService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Contact deleted successfully.");
        }
    }
}
