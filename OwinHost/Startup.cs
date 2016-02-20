using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Routing.Constraints;
using Owin;
using OwinHost.Attributes;
using OwinHost.HttpRouteConstraints;
using OwinHost.MediaTypeFormatters;
using OwinHost.MessageHandlers;

namespace OwinHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            var resolver = new DefaultInlineConstraintResolver();
            resolver.ConstraintMap.Add("goodcolor", typeof(GoodColorConstraint));
            config.MapHttpAttributeRoutes(resolver);

            //config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "Angels",
            //    routeTemplate: "cards1/angels",
            //    defaults: new
            //    {
            //        controller = "Cards1",
            //        action = "GetAngels"
            //    });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

            config.Formatters.Add(new CardImageFormatter());
            config.Formatters.Add(new CardDTOFormatter());

            config.MessageHandlers.Add(new FirstMessageHandler());
            config.MessageHandlers.Add(new SecondMessageHandler());
            //config.MessageHandlers.Add(new ShortcircuitMessageHandler());

            appBuilder.UsePoweredBy("panicoenlaxbox");

            appBuilder.UseWebApi(config);
        }
    }
}