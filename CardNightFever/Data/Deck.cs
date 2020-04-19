using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardNightFever.Data
{
    public class Deck
    {
        public List<PlayingCard> Cards { get; set; }

        public void CreateDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards.Add(new PlayingCard() { Rank = rank, Suit = suit });
                }
            }
        }

        public int HowManyDecks(int playerCount)
        {
            return (int)Math.Ceiling((decimal)playerCount / 2);
        }

        public void CreateMultDecks(int deckCount)
        {
            for (int i = 0; i < deckCount; i++)
            {
                CreateDeck();
            }
        }

        public bool IsEmpty()
        {
            return Cards.Count > 0;
        }

        public PlayingCard DrawCard()
        {
            if (!IsEmpty())
            {
                PlayingCard target = Cards.First();
                Cards.Remove(target);
                return target;
            }
            return null;
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
