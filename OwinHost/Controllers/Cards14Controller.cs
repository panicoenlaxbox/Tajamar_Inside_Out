using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace OwinHost
{
    public class Cards14Controller : CardsControllerBase
    {
        [Route("cards14/anonymous/{id}")]
        public HttpResponseMessage GetAnonymous(int id)
        {
            var card = Context.Cards.Single(d => d.Id == id);
            var model = new
            {
                card.Id,
                card.Name,
                card.Color
            };
            //model.Type = card.Type;
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [Route("cards14/expandoobject/{id}")]
        public HttpResponseMessage GetExpandoObject(int id)
        {
            var card = Context.Cards.Single(d => d.Id == id);
            dynamic model = new ExpandoObject();
            model.Id = card.Id;
            model.Name = card.Name;
            model.Color = card.Color;
            ((IDictionary<string, object>)model)["Type"] = card.Type;
            return Request.CreateResponse(HttpStatusCode.OK, (ExpandoObject)model);
        }

        [Route("cards14/jobject/{id}")]
        public HttpResponseMessage GetJObject(int id)
        {
            var card = Context.Cards.Single(d => d.Id == id);
            var model = new JObject
            {
                {"id", card.Id},
                {"name", card.Name}
            };
            model.Add("color", card.Color);
            model["type"] = card.Type;
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
    }
}
