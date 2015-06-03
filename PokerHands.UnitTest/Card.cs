using System;
using NUnit.Framework;

namespace PokerHands.UnitTest
{
	public class Card : IComparable<Card>
	{
		public int FaceValue { get; set; }
		public char Suit { get; set; }

		public Card(string cardValue)
		{
			FaceValue = GetFaceValue(cardValue[0]);
			Suit = cardValue[1];
		}

		public Card(char faceValue, char suit)
		{
			FaceValue = GetFaceValue(faceValue);
			Suit = suit;
		}

		int GetFaceValue(char faceValue)
		{
			if (faceValue == 'A')
				return 14;
			else if (faceValue == 'K')
				return 13;
			else if (faceValue == 'Q')
				return 12;
			else if (faceValue == 'J')
				return 11;
			else if (faceValue == 'T')
				return 10;
			else
				return int.Parse(faceValue.ToString());
		}
		
		public int CompareTo(Card other)
		{
			return FaceValue.CompareTo(other.FaceValue);
		}
	}
}
