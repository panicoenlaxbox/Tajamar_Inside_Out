using System.Linq;
using Models;

namespace OwinHost
{
    public class Cards5Controller : CardsControllerBase
    {
        public Card Get(int id)
        {
            return Context.Cards.Single(c => c.Id == id);
        }
    }
}