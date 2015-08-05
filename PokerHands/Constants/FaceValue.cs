using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands.Constants
{
	public static class FaceValue
	{
		public const string Ace = "Ace";
		public const string King = "King";
		public const string Queen = "Queen";
		public const string Jack = "Jack";
		public const string Ten = "10";
		public const string Nine = "9";
		public const string Eight = "8";
		public const string Seven = "7";
		public const string Six = "6";
		public const string Five = "5";
		public const string Four = "4";
		public const string Three = "3";
		public const string Two = "2";

		public static int GetFaceValue(string faceValue)
		{
			switch (faceValue)
			{
				case Ace:
					return 14;
				case King:
					return 13;
				case Queen:
					return 12;
				case Jack:
					return 11;
				case Ten:
					return 10;
				default:
					return int.Parse(faceValue);
			}
		}
	}
}
