using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardNightFever.Data;

namespace CardNightFever.Services
{
    public class DealerService
    {
        public List<PlayerHand> Players { get; } = new List<PlayerHand>();
        public DiscardPile DiscardPile { get; private set; }
        public Deck Deck { get; private set; }

        public void NewTable(int players)
        {
            Deck = new Deck();
            DiscardPile = new DiscardPile();
            for (int i =0; i <= players; i++)
            {
                Players.Add(new PlayerHand(i));
            }
        }
    }
}
