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
    [RoutePrefix("api/v1/Process")]
    public class ProcessController : ApiController
    {
        public IProcessRepository ProcessRepository;

        [Route("{id}")]
        [ResponseType(typeof(Process))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(ProcessRepository.Get(id));
        }

        [ResponseType(typeof(Process))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(ProcessRepository.GetAll());
        }

        [ResponseType(typeof(Process))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Process[] Process)
        {
            return Ok(ProcessRepository.Add(Process));
        }

        [ResponseType(typeof(Process))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Process[] Process)
        {
            return Ok(ProcessRepository.Update(Process));
        }

        [ResponseType(typeof(Process))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(ProcessRepository.Delete(id));
        }
    }
}