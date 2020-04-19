using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardNightFever.Data
{
    public class DiscardPile
    {
        public List<PlayingCard> Cards { get; set; }

        public List<PlayingCard> GetDiscards()
        {
            List<PlayingCard> pile = Cards;
            Cards = new List<PlayingCard>();
            return pile;
        }

        public void AddCard(PlayingCard card)
        {
            Cards.Add(card);
        }
    }
}
