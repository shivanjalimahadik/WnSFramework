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
    [RoutePrefix("api/v1/LegalEntity")]
    public class LegalEntityController : ApiController
    {
        public ILegalEntityRepository LegalEntityRepository;

        [Route("{id}")]
        [ResponseType(typeof(LegalEntity))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(LegalEntityRepository.Get(id));
        }

        [ResponseType(typeof(LegalEntity))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(LegalEntityRepository.GetAll());
        }

        [ResponseType(typeof(LegalEntity))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(LegalEntity[] LegalEntity)
        {
            return Ok(LegalEntityRepository.Add(LegalEntity));
        }

        [ResponseType(typeof(LegalEntity))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(LegalEntity[] LegalEntity)
        {
            return Ok(LegalEntityRepository.Update(LegalEntity));
        }

        [ResponseType(typeof(LegalEntity))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(LegalEntityRepository.Delete(id));
        }
    }
}