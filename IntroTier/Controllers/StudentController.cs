using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTier.Controllers
{
    public class StudentController : ApiController
    {
        [HttpGet]
        [Route("api/students/all")]
        public HttpResponseMessage GetAll()
        {
            var data = StudentService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/students/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = StudentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpPost]
        [Route("api/students/create")]
        public HttpResponseMessage Create(StudentDTO s)
        {
            StudentService.Create(s);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPut]
        [Route("api/students/update/{id}")]
        public HttpResponseMessage Update(int id,StudentDTO s)
        {      
            
            var newdata = StudentService.Get(id);

            if (newdata == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found.");
            }
            newdata.Name = s.Name;
            newdata.Cgpa = s.Cgpa;
            newdata.Dept = s.Dept;
            StudentService.Update(newdata);
            return Request.CreateResponse(HttpStatusCode.OK, "Student updated successfully.");
        }

        [HttpDelete]
        [Route("api/students/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                StudentService.Delete(id); 
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message); 
            }
        }

    }
}
