using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Models;

namespace OwinHost
{
    public class Cards1Controller : CardsControllerBase
    {
        public IEnumerable<Card> Get()
        {
            return Context.Cards.ToList();
        }

        [Route("cards1/angels")]
        public IEnumerable<Card> GetAngels()
        {
            return Context.Cards.Where(c => c.Type == "Criatura - Ángel").ToList();
        }
    }
}