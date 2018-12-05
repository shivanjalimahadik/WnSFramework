using Autofac.Extras.DynamicProxy;
using BusinessLogic.Interface;
using Common.LogUtils;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers.api
{
    //[Authorize]
    //[Intercept(typeof(CallLogger))]
    [RoutePrefix("api/v1/UserRoleMapping")]
    public class UserRoleMappingController : ApiController
    {
        public IUserRoleMappingRepository UserRoleMappingRepository;

        [Route("{id}")]
        [ResponseType(typeof(UserRoleMapping))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(UserRoleMappingRepository.Get(id));
        }

        [Route("ids")]
        [ResponseType(typeof(UserRoleMapping))]
        [HttpGet]
        public IHttpActionResult Get([FromUri] object ids)
        {
            IEnumerable<Guid?> data = JsonConvert.DeserializeObject<IEnumerable<Guid?>>(ids.ToString());
            return Ok(UserRoleMappingRepository.Get(data));
            //return Ok();
        }

        [ResponseType(typeof(UserRoleMapping))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(UserRoleMappingRepository.GetAll());
        }

        [ResponseType(typeof(UserRoleMapping))]
        [HttpGet]
        [Route("GetAllUserRole")]
        public IHttpActionResult GetAllUserRoleMapping()
        {
            return Ok(UserRoleMappingRepository.GetAllUserRoleMapping());
        }

        [ResponseType(typeof(UserRoleMapping))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(UserRoleMapping[] resourceCenter)
        {
            return Ok(UserRoleMappingRepository.Add(resourceCenter));
        }

        [ResponseType(typeof(UserRoleMapping))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(UserRoleMapping[] resourceCenter)
        {
            return Ok(UserRoleMappingRepository.Update(resourceCenter));
        }

        [ResponseType(typeof(UserRoleMapping))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(UserRoleMappingRepository.Delete(id));
        }
    }
}