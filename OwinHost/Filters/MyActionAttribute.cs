using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace OwinHost.Attributes
{
    class MyActionAttribute : ActionFilterAttribute
    {
        private readonly string _tag;

        public MyActionAttribute(string tag)
        {
            _tag = tag;
        }

        public bool Shortcircuit { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Debug.Print($"OnActionExecuted {_tag}");  
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Debug.Print($"OnActionExecuting {_tag}");
            if (Shortcircuit)
            {
                var response = actionContext.Request.CreateResponse(HttpStatusCode.OK);
                var stream = new FileStream(@"C:\Tajamar\Images\Finish him.jpg", FileMode.Open);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                actionContext.Response = response;
            }            
        }
    }
}