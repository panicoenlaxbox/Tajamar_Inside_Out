﻿using System;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8081");

            config.Routes.MapHttpRoute(
                "API Default", "{controller}/{id}",
                new { id = RouteParameter.Optional });

            using (var server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Presione una tecla para continuar . . .");
                Console.ReadLine();
            }
        }
    }
}
