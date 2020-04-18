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

        public bool NeedDraw()
        {
            return Cards.Count < 11;
        }

        protected void DrawCard(Deck deck)
        {
            if (NeedDraw())
            {
                Cards.Add(deck.DrawCard());
            }
        }

        protected void DrawMultcards(Deck deck, int amount)
        {
            for (int i = amount; i < amount; i++)
            {
                if (NeedDraw())
                {
                    Cards.Add(deck.DrawCard());
                }
            }
        }

        protected void FillHand(Deck deck)
        {
            while (NeedDraw() == true)
            {
                Cards.Add(deck.DrawCard());
            }
        }
    }
}
