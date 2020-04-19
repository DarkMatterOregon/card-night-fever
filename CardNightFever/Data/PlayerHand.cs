using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CardNightFever.Shared;

namespace CardNightFever.Data
{
    public class PlayerHand
    {
        [Required]
        public int PlayerId { get; set; }
        protected List<PlayingCard> Cards { get; set; }
        public bool IsEmpty 
        { 
            get
            {
                return Cards.Count == 0;
            }
        }
        public bool NeedDraw
        {
            get
            {
                return Cards.Count < 11;
            }
        }
        public int HandSize
        {
            get
            {
                return Cards.Count;
            }
        }

        protected void DrawCard(Deck deck)
        {
            if (NeedDraw)
            {
                Cards.Add(deck.DrawCard());
            }
        }

        protected void DrawMultcards(Deck deck, int amount)
        {
            for (int i = amount; i < amount; i++)
            {
                if (NeedDraw)
                {
                    Cards.Add(deck.DrawCard());
                }
            }
        }

        protected void FillHand(Deck deck)
        {
            while (NeedDraw)
            {
                Cards.Add(deck.DrawCard());
            }
        }

        protected PlayingCard PopCard(int index)
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

        protected PlayingCard PopCard(PlayingCard card)
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

        protected void Discard(DiscardPile pile, int cardIndex)
        {
            PlayingCard card = PopCard(cardIndex);
            if (card != null)
            {
                pile.AddCard(card);
            }
        }

        protected void Discard(DiscardPile pile, PlayingCard cardIn)
        {
            PlayingCard card = PopCard(cardIn);
            if (card != null)
            {
                pile.AddCard(card);
            }
        }
    }
}
