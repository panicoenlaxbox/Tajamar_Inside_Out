using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OwinHost.HttpActionResult
{ 
    class CamelCaseJson<T> : IHttpActionResult
    {
        private readonly T _value;

        public CamelCaseJson(T value)
        {
            _value = value;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(_value, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json)
            };
            response.Headers.Add("X-Convention", "Camel-Case");
            return Task.FromResult(response);
        }
    }
}
