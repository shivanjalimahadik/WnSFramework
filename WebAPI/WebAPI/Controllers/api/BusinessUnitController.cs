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
    [RoutePrefix("api/v1/BusinessUnit")]
    public class BusinessUnitController : ApiController
    {
        public IBusinessUnitRepository BusinessUnitRepository;

        [Route("{id}")]
        [ResponseType(typeof(BusinessUnit))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(BusinessUnitRepository.Get(id));
        }

        [ResponseType(typeof(BusinessUnit))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(BusinessUnitRepository.GetAll());
        }

        [ResponseType(typeof(BusinessUnit))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(BusinessUnit[] BusinessUnit)
        {
            return Ok(BusinessUnitRepository.Add(BusinessUnit));
        }

        [ResponseType(typeof(BusinessUnit))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(BusinessUnit[] BusinessUnit)
        {
            return Ok(BusinessUnitRepository.Update(BusinessUnit));
        }

        [ResponseType(typeof(BusinessUnit))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(BusinessUnitRepository.Delete(id));
        }
    }
}