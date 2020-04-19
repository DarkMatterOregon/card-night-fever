using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardNightFever.Data
{
    public class DiscardPile
    {
        #region Properties
        /// <summary>
        /// The Cards contained in the Discard pile
        /// </summary>
        public List<PlayingCard> Cards { get; set; }
        #endregion Properties

        #region Constructors
        public DiscardPile()
        {
            Cards = new List<PlayingCard>();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Adds a PlayingCard (card) to the top of the discard pile
        /// </summary>
        /// <param name="card"></param>
        public void AddCard(PlayingCard card)
        {
            Cards.Add(card);
        }

        /// <summary>
        /// Removes all the cards in the discard pile and returns them.
        /// </summary>
        /// <returns></returns>
        public List<PlayingCard> PopDiscards()
        {
            List<PlayingCard> pile = Cards;
            Cards = new List<PlayingCard>();
            return pile;
        }
        #endregion Methods
    }
}
