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
    [RoutePrefix("api/v1/Entity")]
    public class EntityController : ApiController
    {
        public IEntityRepository EntityRepository;

        [Route("{id}")]
        [ResponseType(typeof(Entity))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(EntityRepository.Get(id));
        }

        [ResponseType(typeof(Entity))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(EntityRepository.GetAll());
        }

        [ResponseType(typeof(Entity))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Entity[] Entity)
        {
            return Ok(EntityRepository.Add(Entity));
        }

        [ResponseType(typeof(Entity))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Entity[] Entity)
        {
            return Ok(EntityRepository.Update(Entity));
        }

        [ResponseType(typeof(Entity))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(EntityRepository.Delete(id));
        }
    }
}