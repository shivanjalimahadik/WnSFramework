using Autofac.Extras.DynamicProxy;
using BusinessLogic.Interface;
using Common.LogUtils;
using Entities;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers.api
{
    //[Authorize]
    //[Intercept(typeof(CallLogger))]
    [RoutePrefix("api/v1/Resources")]
    public class ResourcesController : ApiController
    {
        public IResourcesRepository ResourcesRepository;

        [Route("{id}")]
        [ResponseType(typeof(Resources))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(ResourcesRepository.Get(id));
        }

        [ResponseType(typeof(Resources))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(ResourcesRepository.GetAll());
        }

        [ResponseType(typeof(Resources))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Resources[] resourceCenter)
        {
            return Ok(ResourcesRepository.Add(resourceCenter));
        }

        [ResponseType(typeof(Resources))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Resources[] resourceCenter)
        {
            return Ok(ResourcesRepository.Update(resourceCenter));
        }

        [ResponseType(typeof(Resources))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(ResourcesRepository.Delete(id));
        }
    }
}