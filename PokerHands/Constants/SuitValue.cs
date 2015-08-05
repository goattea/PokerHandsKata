using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PokerHands.Constants
{
	public static class SuitValue
	{
		public const string Spades = "♠";
		public const string Clubs = "♣";
		public const string Hearts = "♥";
		public const string Diamonds = "♦";

		public static string GetSuit(char suit)
		{
			switch (suit)
			{
				case 'S':
					return Spades;
				case 'C':
					return Clubs;
				case 'H':
					return Hearts;
				case 'D':
					return Diamonds;
			}

			throw new InvalidDataException(string.Format("Could not convert value of '{0}' to a suit", suit));
		}
	}
}
