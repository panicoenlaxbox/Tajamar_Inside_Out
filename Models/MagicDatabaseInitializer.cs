using System.Data.Entity;

namespace Models
{
    public class MagicDatabaseInitializer : CreateDatabaseIfNotExists<MagicContext>
    {
        protected override void Seed(MagicContext context)
        {
            context.Cards.Add(Builder.Card()
                .Name("Agitador trasgo")
                .Color("Rojo")
                .Cost("{2}{R}{R}")
                .Type("Criatura - Guerrero trasgo")
                .ImageUrl("https://image.deckbrew.com/mtg/multiverseid/383258.jpg"));
            context.Cards.Add(Builder.Card()
                .Name("Ahogador de esperanzas")
                .Color("Azul")
                .Cost("{5}{U}")
                .Type("Criatura - Eldrazi")
                .ImageUrl("https://image.deckbrew.com/mtg/multiverseid/401863.jpg"));
            context.Cards.Add(Builder.Card()
                .Name("Alma de la cosecha")
                .Color("Verde")
                .Cost("{4}{G}{G}")
                .Type("Criatura - Elemental")
                .ImageUrl("https://image.deckbrew.com/mtg/multiverseid/389684.jpg"));
            context.Cards.Add(Builder.Card()
                .Name("Ángel bendición de batalla")
                .Color("Blanco")
                .Cost("{3}{W}{W}")
                .Type("Criatura - Ángel")
                .ImageUrl("https://image.deckbrew.com/mtg/multiverseid/397766.jpg"));
            context.Cards.Add(Builder.Card()
                .Name("Ángel caído")
                .Color("Negro")
                .Cost("{3}{B}{B}")
                .Type("Criatura - Ángel")
                .ImageUrl("https://image.deckbrew.com/mtg/multiverseid/26660.jpg"));
            context.Cards.Add(Builder.Card()
                .Name("Esfinge de la isla Jwar")
                .Color("Azul")
                .Cost("{4}{U}{U}")
                .Type("Criatura - Esfinge")
                .ImageUrl("https://image.deckbrew.com/mtg/multiverseid/389686.jpg"));
        }
    }
}