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
    [RoutePrefix("api/v1/CostCenter")]
    public class CostCenterController : ApiController
    {
        public ICostCenterRepository CostCenterRepository;

        [Route("{id}")]
        [ResponseType(typeof(CostCenter))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(CostCenterRepository.Get(id));
        }

        [ResponseType(typeof(CostCenter))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(CostCenterRepository.GetAll());
        }

        [ResponseType(typeof(CostCenter))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(CostCenter[] CostCenter)
        {
            return Ok(CostCenterRepository.Add(CostCenter));
        }

        [ResponseType(typeof(CostCenter))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(CostCenter[] CostCenter)
        {
            return Ok(CostCenterRepository.Update(CostCenter));
        }

        [ResponseType(typeof(CostCenter))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(CostCenterRepository.Delete(id));
        }
    }
}