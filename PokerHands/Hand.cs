using System.Collections.Generic;
using System.Linq;
using PokerHands.HandSets;

namespace PokerHands
{
	public class Hand
	{
		public List<Card> Cards = new List<Card>();
		public IHandSet HandSet { get; private set; }

		public Hand(string hand)
		{
			foreach (var card in hand.Split(' '))
			{
				Cards.Add(new Card(card));
			}
			SortHand();
		}

		public Hand(List<Card> cards)
		{
			Cards = cards;
		}


		private void SortHand()
		{
			Cards.Sort();
			Cards.Reverse();
		}

		public void Analyze()
		{
			HandSet = HandSetFactory.Generate(this);
		}

		public override string ToString()
		{
			return string.Concat(Cards.Select(c => string.Format("{0}{1} ", c.Face, c.Suit)).ToArray()).TrimEnd();
		}
	}
}
