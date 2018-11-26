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
    [RoutePrefix("api/v1/Roles")]
    public class RolesController : ApiController
    {
        public IRolesRepository RolesRepository;

        [Route("{id}")]
        [ResponseType(typeof(Roles))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(RolesRepository.Get(id));
        }

        [ResponseType(typeof(Roles))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(RolesRepository.GetAll());
        }

        [ResponseType(typeof(Roles))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Roles[] resourceCenter)
        {
            return Ok(RolesRepository.Add(resourceCenter));
        }

        [ResponseType(typeof(Roles))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Roles[] resourceCenter)
        {
            return Ok(RolesRepository.Update(resourceCenter));
        }

        [ResponseType(typeof(Roles))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(RolesRepository.Delete(id));
        }
    }
}