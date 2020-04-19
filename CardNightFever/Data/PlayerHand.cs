using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardNightFever.Shared;

namespace CardNightFever.Data
{
    public class PlayerHand
    {
        #region Variables
        // stores the player's id
        protected int playerId;
        #endregion Variables

        #region Properties
        /// <summary>
        /// Indicates the player's ID. Needs to be unique.
        /// </summary>
        public int PlayerId { get; }
        /// <summary>
        /// The list of cards contained in the Player's Hand
        /// </summary>
        public List<PlayingCard> Cards { get; set; }
        /// <summary>
        /// Indicates if the player has no cards.
        /// </summary>
        public bool IsEmpty 
        { 
            get
            {
                return Cards.Count == 0;
            }
        }
        /// <summary>
        /// Indicates if a player has fewer than 11 cards and needs to draw.
        /// </summary>
        public bool NeedDraw
        {
            get
            {
                return Cards.Count < 11;
            }
        }
        /// <summary>
        /// The amount of cards in a Player's Hand
        /// </summary>
        public int HandSize
        {
            get
            {
                return Cards.Count;
            }
        }
        #endregion Properties

        #region Constructors
        public PlayerHand(int id)
        {
            PlayerId = id;
            Cards = new List<PlayingCard>();
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Draws the top card off of the Deck (deck).
        /// </summary>
        /// <param name="deck"></param>
        public void DrawCard(Deck deck)
        {
            if (NeedDraw)
            {
                Cards.Add(deck.DrawCard());
            }
        }

        /// <summary>
        /// Draws multiple (amount) cards off the top of the Deck (deck).
        /// </summary>
        /// <param name="deck"></param>
        /// <param name="amount"></param>
        public void DrawMultcards(Deck deck, int amount)
        {
            for (int i = amount; i < amount; i++)
            {
                if (NeedDraw)
                {
                    Cards.Add(deck.DrawCard());
                }
            }
        }

        /// <summary>
        /// Draws cards off of the top of the Deck (deck) until the hand has 11
        /// cards.
        /// </summary>
        /// <param name="deck"></param>
        public void FillHand(Deck deck)
        {
            while (NeedDraw)
            {
                Cards.Add(deck.DrawCard());
            }
        }

        /// <summary>
        /// Removes the Card by index (index) and returns it.
        /// Returns null if no card is found.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>PlayingCard</returns>
        public PlayingCard PopCard(int index)
        {
            if (!IsEmpty)
            {
                PlayingCard target = Cards[index];
                Cards.RemoveAt(index);
                return target;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Removes a card based on the Playing Card (card) that is passed in
        /// and returns it.
        /// Returns null if card doesn't exist in player's hand.
        /// </summary>
        /// <param name="card"></param>
        /// <returns>PlayingCard</returns>
        public PlayingCard PopCard(PlayingCard card)
        {
            if (!IsEmpty)
            {
                if (Cards.Contains(card))
                {
                    PlayingCard target = Cards[Cards.IndexOf(card)];
                    Cards.Remove(card);
                    return target;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Removes one card from the player's hand by index (cardIndex) and
        /// places it into the discard pile (pile). If card doesn't exist,
        /// it won't be placed in the discard pile.
        /// </summary>
        /// <param name="pile"></param>
        /// <param name="cardIndex"></param>
        public void Discard(DiscardPile pile, int cardIndex)
        {
            PlayingCard card = PopCard(cardIndex);
            if (card != null)
            {
                pile.AddCard(card);
            }
        }

        /// <summary>
        /// Removes one card from the player's hand based on card (cardIn)
        /// passed in and places it into the discard pile (pile).
        /// If card doesn't exist, nothing happens.
        /// </summary>
        /// <param name="pile"></param>
        /// <param name="cardIn"></param>
        public void Discard(DiscardPile pile, PlayingCard cardIn)
        {
            PlayingCard card = PopCard(cardIn);
            if (card != null)
            {
                pile.AddCard(card);
            }
        }
        #endregion Methods
    }
}
