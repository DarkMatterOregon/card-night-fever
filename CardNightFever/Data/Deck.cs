using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardNightFever.Data
{
    public class Deck
    {
        #region Properties
        /// <summary>
        /// The list of Cards in the Deck.
        /// </summary>
        public List<PlayingCard> Cards { get; set; }
        /// <summary>
        /// Indicates if the Deck has no cards in it.
        /// </summary>
        public bool IsEmpty
        {
            get
            {
                return Cards.Count == 0;
            }
        }
        #endregion Properties

        #region Constructors
        public Deck()
        {
            Cards = new List<PlayingCard>();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Creates a single deck of cards and stores it in the Cards Property.
        /// </summary>
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

        /// <summary>
        /// Returns the number of Decks that should be generated based on
        /// the amount of players (playerCount).
        /// </summary>
        /// <param name="playerCount"></param>
        /// <returns>int</returns>
        public int HowManyDecks(int playerCount)
        {
            return (int)Math.Ceiling((decimal)playerCount / 2);
        }

        /// <summary>
        /// Creates and stores a number (deckCount) of decks in the Cards
        /// property of the Deck.
        /// </summary>
        /// <param name="deckCount"></param>
        public void CreateMultDecks(int deckCount)
        {
            for (int i = 0; i < deckCount; i++)
            {
                CreateDeck();
            }
        }

        /// <summary>
        /// Removes a card from the top of the deck and returns it.
        /// </summary>
        /// <returns>PlayingCard</returns>
        public PlayingCard DrawCard()
        {
            if (!IsEmpty)
            {
                PlayingCard target = Cards.First();
                Cards.Remove(target);
                return target;
            }
            return null;
        }

        /// <summary>
        /// Shuffles the cards in the Deck around in random order.
        /// </summary>
        public void ShuffleCards()
        {
            Random random = new Random();
            int cardsCount = Cards.Count;

            for (int i = 0; i < cardsCount; i++)
            {
                int index = random.Next(0, cardsCount);
                PlayingCard temp = Cards[i];
                Cards[i] = Cards[index];
                Cards[index] = temp;
            }
        }
        #endregion Methods
    }
}