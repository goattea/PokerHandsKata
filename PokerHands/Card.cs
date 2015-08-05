using System;
using System.IO;
using PokerHands.Constants;

namespace PokerHands
{
	public class Card : IComparable<Card>
	{
		public string Face { get; private set; }
		public char FaceChar { get; private set; }
		public string Suit { get; private set; }
		public char SuitChar { get; private set; }
		
		public Card(string cardValue)
		{
			Face = GetFaceStringFromChar(cardValue[0]);
			FaceChar = cardValue[0];
			Suit = SuitValue.GetSuit(cardValue[1]);
			SuitChar = cardValue[1];
		}

		private static string GetFaceStringFromChar(char faceValue)
		{
			switch (faceValue)
			{
				case 'A':
					return FaceValue.Ace;
				case 'K':
					return FaceValue.King;
				case 'Q':
					return FaceValue.Queen;
				case 'J':
					return FaceValue.Jack;
				case 'T':
					return FaceValue.Ten;
				case '9':
					return FaceValue.Nine;
				case '8':
					return FaceValue.Eight;
				case '7':
					return FaceValue.Seven;
				case '6':
					return FaceValue.Six;
				case '5':
					return FaceValue.Five;
				case '4':
					return FaceValue.Four;
				case '3':
					return FaceValue.Three;
				case '2':
					return FaceValue.Two;
			}

			throw new InvalidDataException(string.Format("Could not convert {0} to a face value", faceValue));
		}

		public int CompareTo(Card other)
		{
			var myFaceValue = FaceValue.GetFaceValue(Face);
			var otherFaceValue = FaceValue.GetFaceValue(other.Face);

			return myFaceValue.CompareTo(otherFaceValue);
		}

		public override string ToString()
		{
			return string.Format("{0} of {1}", Face, Suit);
		}
	}
}
