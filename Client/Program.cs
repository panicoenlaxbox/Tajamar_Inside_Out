using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CacheCow.Client;
using CacheCow.Client.Headers;

namespace Client
{
    class Program
    {
        private const string Url = "http://localhost:65052/api/cards/1";

        static void Main(string[] args)
        {
            //Request();
            //RequestWithCacheCow();
            RequestWithWebRequestHandler();
            Console.ReadLine();
        }

        private static void RequestWithWebRequestHandler()
        {
            HttpClient client = new HttpClient(new WebRequestHandler()
            {
                CachePolicy = new RequestCachePolicy(RequestCacheLevel.Default)
            });
            var response = client.GetAsync(Url).Result;
            var message = response.StatusCode.ToString();
            Console.WriteLine(message);
            response = client.GetAsync(Url).Result;
            message = response.StatusCode.ToString();
            Console.WriteLine(message);
        }

        static void Request()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(Url).Result;
                var message = response.StatusCode.ToString();
                Console.WriteLine(message);
                response = client.GetAsync(Url).Result;
                message = response.StatusCode.ToString();
                Console.WriteLine(message);
            }
        }

        static void RequestWithCacheCow()
        {
            var client = new HttpClient(new CachingHandler()
            {
                InnerHandler = new HttpClientHandler()
            });

            var response = client.GetAsync(Url).Result;
            var message = response.StatusCode.ToString();
            Console.WriteLine(message);

            response = client.GetAsync(Url).Result;
            message = response.StatusCode.ToString();
            Console.WriteLine(message);
        }
    }
}
