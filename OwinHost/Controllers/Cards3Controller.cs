using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Models;

namespace OwinHost
{
    public class Cards3Controller : CardsControllerBase
    {
        //[Route("cards3/{color}")]
        [Route("cards3/{color:goodcolor}")]
        public IEnumerable<Card> GetGoodColors(string color)
        {
            return Context.Cards.Where(c => c.Color == color);
        }
    }
}