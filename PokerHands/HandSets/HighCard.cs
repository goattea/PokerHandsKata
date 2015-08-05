using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands.HandSets
{
	public class HighCard : IHandSet
	{
		public double Probability
		{
			get { return Constants.Probability.HighCard; }
		}

		public string Name
		{
			get { return ToString(); }
		}

		public List<Card> Cards
		{
			get;
			private set;
		}


		public HighCard(Hand hand)
		{
			Cards = hand.Cards;
		}

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((HighCard) other) : 
				other.Probability.CompareTo(Probability);
		}

		public int CompareTo(HighCard other)
		{

			for (var i = 0; i < Cards.Count; i++)
			{
				var compareResult = Cards[i].CompareTo(other.Cards[i]);
				if (compareResult != 0)
				{
					return compareResult;
				}
			}

			return 0;
		}

		public override string ToString()
		{
			return string.Format("{0} High", Cards.First().Face);
		}
	}
}