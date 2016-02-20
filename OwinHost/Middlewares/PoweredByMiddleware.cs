using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace OwinHost.MessageHandlers
{
    public class PoweredByMiddleware : OwinMiddleware
    {
        private readonly string _by;

        public PoweredByMiddleware(OwinMiddleware next, string by) : base(next)
        {
            _by = by;
        }

        public override Task Invoke(IOwinContext context)
        {
            Debug.WriteLine("PoweredByMiddleware pre-processing");
            context.Response.Headers.Append("X-Powered-by", _by);
            var t = Next.Invoke(context);
            Debug.WriteLine("PoweredByMiddleware post-processing");
            return t;
        }
    }
}