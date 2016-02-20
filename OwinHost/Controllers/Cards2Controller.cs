using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Models;

namespace OwinHost
{
    public class Cards2Controller : CardsControllerBase
    {
        public IEnumerable<Card> Get()
        {
            return Context.Cards.ToList();
        }

        //public IHttpActionResult Get(string id)
        //{
        //    int identifier;
        //    var card = int.TryParse(id, out identifier) ?
        //        Context.Cards.SingleOrDefault(c => c.Id == identifier) :
        //        Context.Cards.SingleOrDefault(c => c.Name == id);
        //    if (card != null)
        //    {
        //        return Ok(card);
        //    }
        //    return NotFound();
        //}

        [Route("cards2/{id:int}")]
        public Card Get(int id)
        {
            return Context.Cards.SingleOrDefault(c => c.Id == id);
        }

        public Card Get(string id)
        {
            return Context.Cards.SingleOrDefault(c => c.Name == id);
        }
    }
}