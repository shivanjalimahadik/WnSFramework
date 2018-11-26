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
    [RoutePrefix("api/v1/OrganizationUnit")]
    public class OrganizationUnitController : ApiController
    {
        public IOrganizationUnitRepository OrganizationUnitRepository;

        [Route("{id}")]
        [ResponseType(typeof(OrganizationUnit))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(OrganizationUnitRepository.Get(id));
        }

        [ResponseType(typeof(OrganizationUnit))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(OrganizationUnitRepository.GetAll());
        }

        [ResponseType(typeof(OrganizationUnit))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(OrganizationUnit[] OrganizationUnit)
        {
            return Ok(OrganizationUnitRepository.Add(OrganizationUnit));
        }

        [ResponseType(typeof(OrganizationUnit))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(OrganizationUnit[] OrganizationUnit)
        {
            return Ok(OrganizationUnitRepository.Update(OrganizationUnit));
        }

        [ResponseType(typeof(OrganizationUnit))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(OrganizationUnitRepository.Delete(id));
        }
    }
}