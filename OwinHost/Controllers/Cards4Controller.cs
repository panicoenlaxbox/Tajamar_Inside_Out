using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OwinHost.HttpActionResult;

namespace OwinHost
{
    public class Cards4Controller : CardsControllerBase
    {
        //public HttpResponseMessage Get()
        //{
        //    var json = JsonConvert.SerializeObject(Context.Cards.ToList(), new JsonSerializerSettings()
        //    {
        //        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        //        Formatting = Formatting.Indented
        //    });
        //    var response = new HttpResponseMessage
        //    {
        //        StatusCode = HttpStatusCode.OK,
        //        Content = new StringContent(json)
        //    };
        //    response.Headers.Add("X-Convention", "Camel-Case");
        //    return response;
        //}

        public IHttpActionResult Get()
        {
            return new CamelCaseJson<IEnumerable<Card>>(Context.Cards.ToList());
        }
    }
}