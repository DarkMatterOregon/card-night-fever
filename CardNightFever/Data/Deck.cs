using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardNightFever.Data
{
    public class Deck
    {
        public List<PlayingCard> Cards { get; set; }

        public PlayingCard DrawCard()
        {
            PlayingCard target = Cards.First();
            Cards.Remove(target);
            return target;
        }

        public void ShuffleCards()
        {
            Random random = new Random();

            for (int i = 0; i < Cards.Count; i++)
            {
                PlayingCard c = Cards[i];
                Cards.Insert(random.Next(0, Cards.Count), c);
                Cards.Remove(c);
            }
        }
    }
}
