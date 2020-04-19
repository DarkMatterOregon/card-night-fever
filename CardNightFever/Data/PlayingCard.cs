using System;
using System.Net.Security;
using System.Runtime.CompilerServices;

namespace CardNightFever.Data
{
    public class PlayingCard
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        public string ImageSrc => $"/images/English_pattern_{Rank.ToSvgName()}_of_{Suit.ToSvgName()}.svg";
    }
    public enum Suit { Clubs, Diamonds, Hearts, Spades }
    public enum Rank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }

    public static class EnumExtensions
    {
        public static string ToSvgName(this Rank rank)
        {
            string[] svgNames = {"ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king"};
            return svgNames[(int)rank];
        }

        public static string ToSvgName(this Suit suit)
        {
            string[] svgNames = { "clubs", "diamonds", "hearts", "spades" }; // could just be tolower()...
            return svgNames[(int)suit];
        }
    }
}
