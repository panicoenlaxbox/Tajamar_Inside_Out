using System.Web.Http.Filters;

namespace OwinHost.Attributes
{
    public class CustomHeaderAttribute : ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public CustomHeaderAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response.Headers.Add(_name, _value);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}