namespace Models
{
    class CardBuilder
    {
        private readonly Card _card;

        public CardBuilder()
        {
            _card = new Card();
        }

        public CardBuilder Name(string name)
        {
            _card.Name = name;
            return this;
        }

        public CardBuilder Color(string color)
        {
            _card.Color = color;
            return this;
        }

        public CardBuilder Cost(string cost)
        {
            _card.Cost = cost;
            return this;
        }

        public CardBuilder Type(string type)
        {
            _card.Type = type;
            return this;
        }

        public CardBuilder CardText(string cardText)
        {
            _card.CardText = cardText;
            return this;
        }

        public CardBuilder FlavorText(string flavorText)
        {
            _card.FlavorText = flavorText;
            return this;
        }

        public CardBuilder ImageUrl(string imageUrl)
        {
            _card.ImageUrl = imageUrl;
            return this;
        }

        public static implicit operator Card(CardBuilder builder)
        {
            return builder._card;
        }
    }
}