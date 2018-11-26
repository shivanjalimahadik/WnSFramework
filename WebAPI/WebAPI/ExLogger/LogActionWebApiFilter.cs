using log4net;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI.ExLogger
{
    public class LogActionWebApiFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Instance of the Log4Net log.
        /// </summary>
        //[Dependency]  //Part 1
        public ILog Log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //This function will execute before the web api controller
        //Part 2
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //This is where you will add any custom logging code
            //that will execute before your method runs.
            Log.DebugFormat(string.Format("Request {0} {1}"
               , actionContext.Request.Method.ToString()
                  , actionContext.Request.RequestUri.ToString()));
        }

        //This function will execute after the web api controller
        //Part 3
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //This is where you will add any custom logging code that will
            //execute after your method runs.
            Log.DebugFormat(string.Format("{0} Response Code: {1}"
                       , actionExecutedContext.Request.RequestUri.ToString()
                          , actionExecutedContext.Response != null ? actionExecutedContext.Response.StatusCode.ToString() : ""));
        }
    }
}