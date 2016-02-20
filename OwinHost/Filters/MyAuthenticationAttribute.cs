using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace OwinHost.Attributes
{
    class MyAuthenticationAttribute : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple { get; }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            Debug.Print("AuthenticateAsync");
            return Task.CompletedTask;
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Debug.Print("ChallengeAsync");
            return Task.CompletedTask;
        }
    }
}