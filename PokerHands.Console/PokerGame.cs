using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands.Console
{
	internal class PokerGame
	{
		public PlayerHand Player1 { get; private set; }
		public PlayerHand Player2 { get; private set; }

		public PokerGame(string input)
		{
			//Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH
			var hands = input.Replace("  ", "|").Split('|');
			var player = GetPlayer(hands[0]);
			var hand = GetHand(hands[0]);

			Player1 = new PlayerHand(player, hand);

			player = GetPlayer(hands[1]);
			hand = GetHand(hands[1]);

			Player2 = new PlayerHand(player, hand);
		}

		private string GetPlayer(string handString )
		{
			return handString.Split(':')[0];
		}

		private string GetHand(string handString)
		{
			return handString.Split(':')[1].Trim();
		}
	}
}
