using System;
using System.Net.Security;

namespace CardNightFever.Data
{
    public class PlayingCard
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
    }
    public enum Suit { Clubs, Diamonds, Hearts, Spades }
    public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

}
