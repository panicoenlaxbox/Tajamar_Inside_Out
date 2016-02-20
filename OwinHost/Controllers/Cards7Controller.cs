using System.Collections.Generic;
using System.Linq;
using Models;
using OwinHost.Attributes;

namespace OwinHost
{
    [CustomHeader("X-Powered-By", "Tajamar")]
    public class Cards7Controller : CardsControllerBase
    {
        public IEnumerable<Card> Get()
        {
            return Context.Cards.ToList();
        }

       
        public Card Get(int id)
        {
            return Context.Cards.Single(c => c.Id == id);
        }
    }
}