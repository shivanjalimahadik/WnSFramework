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
    [RoutePrefix("api/v1/Users")]
    public class UsersController : ApiController
    {
        public IUsersRepository UsersRepository;

        [Route("{id}")]
        [ResponseType(typeof(Users))]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            return Ok(UsersRepository.Get(id));
        }

        [ResponseType(typeof(Users))]
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(UsersRepository.GetAll());
        }

        [ResponseType(typeof(Users))]
        [HttpPost]
        [Route("")]
        public IHttpActionResult Save(Users[] Users)
        {
            return Ok(UsersRepository.Add(Users));
        }

        [ResponseType(typeof(Users))]
        [Route("")]
        [HttpPut]
        public IHttpActionResult Update(Users[] Users)
        {
            return Ok(UsersRepository.Update(Users));
        }

        [ResponseType(typeof(Users))]
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(string id)
        {
            return Ok(UsersRepository.Delete(id));
        }
    }
}