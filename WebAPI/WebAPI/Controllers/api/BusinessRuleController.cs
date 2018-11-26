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
    [RoutePrefix("api/v1/BusinessRule")]
    public class BusinessRuleController : ApiController
    {
        public IBusinessRuleRepository BusinessRuleRepository;

        [Route("{id}")]
        [ResponseType(typeof(BusinessRule))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(BusinessRuleRepository.Get(id));
        }

        [ResponseType(typeof(BusinessRule))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(BusinessRuleRepository.GetAll());
        }

        [ResponseType(typeof(BusinessRule))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(BusinessRule[] BusinessRule)
        {
            return Ok(BusinessRuleRepository.Add(BusinessRule));
        }

        [ResponseType(typeof(BusinessRule))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(BusinessRule[] BusinessRule)
        {
            return Ok(BusinessRuleRepository.Update(BusinessRule));
        }

        [ResponseType(typeof(BusinessRule))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(BusinessRuleRepository.Delete(id));
        }
    }
}