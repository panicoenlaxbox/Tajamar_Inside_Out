using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace OwinHost.MessageHandlers
{
    public class SecondMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.Print("SecondMessageHandler pre-processing");
            var response = await base.SendAsync(request, cancellationToken);
            Debug.Print("SecondMessageHandler post-processing");
            return response;
        }
    }
}