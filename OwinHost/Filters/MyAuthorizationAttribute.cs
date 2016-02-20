using System.Diagnostics;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OwinHost.Attributes
{
    class MyAuthorizationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            Debug.Print("OnAuthorization");
        }
    }
}