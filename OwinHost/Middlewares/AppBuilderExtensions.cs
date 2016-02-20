using Owin;

namespace OwinHost.MessageHandlers
{
    public static class AppBuilderExtensions
    {
        public static void UsePoweredBy(this IAppBuilder app, string by)
        {            
            app.Use<PoweredByMiddleware>(by);
        }
    }
}