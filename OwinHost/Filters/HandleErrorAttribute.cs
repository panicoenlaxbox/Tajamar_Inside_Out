using System.Diagnostics;
using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Filters;

namespace OwinHost.Attributes
{
    class HandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Debug.Print("OnException");
        }
    }
}