using BLL.DTOs;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTier.Controllers
{
    public class TaskController : ApiController
    {
        [HttpPost]
        [Route("api/Tasks/create")]
        public HttpResponseMessage Create(TaskDTO c)
        {
            TaskService.Create(c);
            return Request.CreateResponse(HttpStatusCode.OK, "Task created successfully.");
        }

        [HttpGet]
        [Route("api/Tasks/all")]
        public HttpResponseMessage GetAll()
        {
            var data = TaskService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
