using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands.UnitTest
{
	public class Hand
	{
		public List<Card> Cards = new List<Card>();

		public Hand(string hand)
		{
			//"2H 3D 5S 9C KD"
			string[] handArray = hand.Split(' ');
			Cards.Add(new Card(handArray[0]));
			Cards.Add(new Card(handArray[1]));
			Cards.Add(new Card(handArray[2]));
			Cards.Add(new Card(handArray[3]));
			Cards.Add(new Card(handArray[4]));
			
			SortHand();
		}

		private void SortHand()
		{
			Cards.Sort();
		}
	}
}
