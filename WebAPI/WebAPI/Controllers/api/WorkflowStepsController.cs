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
    [RoutePrefix("api/v1/WorkflowSteps")]
    public class WorkflowStepsController : ApiController
    {
        public IWorkflowStepsRepository WorkflowStepsRepository;

        [Route("{id}")]
        [ResponseType(typeof(WorkflowSteps))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(WorkflowStepsRepository.Get(id));
        }

        [ResponseType(typeof(WorkflowSteps))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(WorkflowStepsRepository.GetAll());
        }

        [ResponseType(typeof(WorkflowSteps))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(WorkflowSteps[] resourceCenter)
        {
            return Ok(WorkflowStepsRepository.Add(resourceCenter));
        }

        [ResponseType(typeof(WorkflowSteps))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(WorkflowSteps[] resourceCenter)
        {
            return Ok(WorkflowStepsRepository.Update(resourceCenter));
        }

        [ResponseType(typeof(WorkflowSteps))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(WorkflowStepsRepository.Delete(id));
        }
    }
}