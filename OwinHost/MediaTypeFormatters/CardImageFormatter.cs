using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Models;

namespace OwinHost.MediaTypeFormatters
{
    public class CardImageFormatter : MediaTypeFormatter
    {
        public CardImageFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/jpeg"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(Card);
        }

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            byte[] response;
            using (var client = new HttpClient())
            {
                response = await client.GetByteArrayAsync(((Card)value).ImageUrl);
            }
            await writeStream.WriteAsync(response, 0, response.Length);
            content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        }
    }
}