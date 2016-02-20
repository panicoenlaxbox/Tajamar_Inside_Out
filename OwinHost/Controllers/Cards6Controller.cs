using System.Web.Http;
using Models;
using OwinHost.DTO;

namespace OwinHost
{
    public class Cards6Controller : CardsControllerBase
    {
        public IHttpActionResult Post(CardDTO card)
        {
            var newCard = new Card
            {
                Id = 1,
                Name = card.Name,
                Color = card.Color,
                Cost = card.Cost,
                Type = card.Type,
                CardText = card.CardText,
                FlavorText = card.FlavorText
            };
            return CreatedAtRoute("DefaultApi", new { id = newCard.Id }, card);
        }
    }
}