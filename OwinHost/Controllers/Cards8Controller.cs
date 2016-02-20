using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Models;
using OwinHost.Attributes;

namespace OwinHost
{
    public class Cards8Controller : CardsControllerBase
    {
        [MyAction("first")]
        [MyAction("second")]
        [MyAction("third", Shortcircuit = true)]
        [MyAuthentication]
        [MyAuthorization]
        [HandleError]
        public IEnumerable<Card> Get()
        {
            Debug.Print("Get");
            return Context.Cards.ToList();
        }
    }
}