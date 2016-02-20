using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Models;
using OwinHost.Attributes;

namespace OwinHost
{
    public class Cards11Controller : CardsControllerBase
    {
        [MyAction("first")]
        [MyAction("second")]
        public IEnumerable<Card> Get()
        {
            Debug.Print("Get");
            return Context.Cards.ToList();
        }
    }
}