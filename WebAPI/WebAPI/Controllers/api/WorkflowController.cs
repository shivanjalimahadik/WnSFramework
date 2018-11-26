using Autofac.Extras.DynamicProxy;
using BusinessLogic.Interface;
using Common.LogUtils;
using Entities;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    //[Authorize]
    //[Intercept(typeof(CallLogger))]
    [RoutePrefix("api/v1/Workflow")]
    public class WorkflowController : ApiController
    {
        public IWorkflowRepository WorkflowRepository;

        [Route("{id}")]
        [ResponseType(typeof(Workflow))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(WorkflowRepository.Get(id));
        }

        [ResponseType(typeof(Workflow))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(WorkflowRepository.GetAll());
        }

        [ResponseType(typeof(Workflow))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Workflow[] resourceCenter)
        {
            return Ok(WorkflowRepository.Add(resourceCenter));
        }

        [ResponseType(typeof(Workflow))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Workflow[] resourceCenter)
        {
            return Ok(WorkflowRepository.Update(resourceCenter));
        }

        [ResponseType(typeof(Workflow))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(WorkflowRepository.Delete(id));
        }
    }
}