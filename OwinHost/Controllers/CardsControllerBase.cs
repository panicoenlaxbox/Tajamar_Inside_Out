using System.Web.Http;
using Models;

namespace OwinHost
{
    public abstract class CardsControllerBase : ApiController
    {
        protected readonly MagicContext Context;

        public CardsControllerBase()
        {
            Context = new MagicContext();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
            base.Dispose(disposing);
        }
    }
}