using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OwinHost.MessageHandlers
{
    public class FirstMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.Print("FirstMessageHandler pre-processing");
            var response = await base.SendAsync(request, cancellationToken);
            Debug.Print("FirstMessageHandler post-processing");
            return response;
        }
    }
}