using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using OwinHost.DTO;

namespace OwinHost.MediaTypeFormatters
{
    public class SynchronousCardDTOFormatter : BufferedMediaTypeFormatter
    {
        public SynchronousCardDTOFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(CardDTO);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public override object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var rootPath = Path.GetTempPath();
            var provider = new MultipartFormDataStreamProvider(rootPath);
            var multipart = content.ReadAsMultipartAsync(provider).Result;
            var card = new CardDTO();
            if (multipart.FileData.Any())
            {
                card.Image = GetImage(multipart);
            }
            card.Name = multipart.FormData["Name"];
            card.Color = multipart.FormData["Color"];
            card.Cost = multipart.FormData["Cost"];
            card.Type = multipart.FormData["Type"];
            card.CardText = multipart.FormData["CardText"];
            card.FlavorText = multipart.FormData["FlavorText"];
            return card;
        }

        private static ImageDTO GetImage(MultipartFormDataStreamProvider multipart)
        {
            var file = multipart.FileData.First();
            var fileName = WebUtility
                .UrlDecode(file.Headers.ContentDisposition.FileName)
                .TrimStart('"')
                .TrimEnd('"');
            return new ImageDTO
            {
                FileName = fileName,
                Path = file.LocalFileName,
                MediaType = file.Headers.ContentType.MediaType
            };
        }
    }
}