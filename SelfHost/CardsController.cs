using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Models;

namespace SelfHost
{
    public class CardsController : ApiController
    {
        private readonly MagicContext _context;

        public CardsController()
        {
            _context = new MagicContext();
        }

        public IEnumerable<Card> Get()
        {
            return _context.Cards.ToList();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}