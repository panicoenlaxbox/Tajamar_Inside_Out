using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;

namespace OwinHost.HttpRouteConstraints
{
    class GoodColorConstraint : IHttpRouteConstraint
    {
        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values,
            HttpRouteDirection routeDirection)
        {
            return new[] { "blanco", "azul" }.Contains(values[parameterName].ToString().ToLower());
        }
    }
}