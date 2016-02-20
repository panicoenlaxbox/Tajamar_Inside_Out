using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OwinHost.MessageHandlers
{
    public class ShortcircuitMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {            
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.BadRequest));
        }    
    }
}