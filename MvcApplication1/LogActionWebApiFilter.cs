using System;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;

namespace MvcApplication1
{

    public class LogActionWebApiFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // pre-processing
            Logging.RequestResponseEvents.Log.LogInfoMessage("OnActionExecuted Request " + actionContext.Request.RequestUri.ToString());
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
            }

            Logging.RequestResponseEvents.Log.LogInfoMessage("OnActionExecuted Response " +  actionExecutedContext.Response.StatusCode.ToString());
        }


    }
}