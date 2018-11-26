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
    [RoutePrefix("api/v1/ResourceCenter")]
    public class ResourceCenterController : ApiController
    {
        public IResourceCenterRepository ResourceCenterRepository;

        [Route("{id}")]
        [ResponseType(typeof(ResourceCenter))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(ResourceCenterRepository.Get(id));
        }

        [ResponseType(typeof(ResourceCenter))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(ResourceCenterRepository.GetAll());
        }

        [ResponseType(typeof(ResourceCenter))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(ResourceCenter[] resourceCenter)
        {
            return Ok(ResourceCenterRepository.Add(resourceCenter));
        }

        [ResponseType(typeof(ResourceCenter))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(ResourceCenter[] resourceCenter)
        {
            return Ok(ResourceCenterRepository.Update(resourceCenter));
        }

        [ResponseType(typeof(ResourceCenter))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(ResourceCenterRepository.Delete(id));
        }
    }
}