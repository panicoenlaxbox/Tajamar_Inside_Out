using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using Models;

namespace WebHost.Controllers
{
    public class CardsController : ApiController
    {
        private readonly MagicContext _context;

        public CardsController()
        {
            _context = new MagicContext();
        }

        /// <summary>
        /// Devuelve todas las cartas
        /// </summary>
        /// <returns></returns>
        [ResponseType(typeof(Card))]
        public IEnumerable<Card> Get()
        {
            return _context.Cards.ToList();
        }

        /// <summary>
        /// Devuelve una carta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Card Get(int id)
        {
            return _context.Cards.SingleOrDefault(c => c.Id == id);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
    }
}