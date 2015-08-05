using System;
using System.Linq;

namespace PokerHands.HandSets
{
	public class HighCard : IHandSet
	{
		private Card _highestCard;

		public double Probability
		{
			get { return Constants.Probability.HighCard; }
		}

		public string Name
		{
			get { return ToString(); }
		}

		public Hand Hand
		{
			get;
			private set;
		}


		public HighCard(Hand hand)
		{
			Hand = hand;
			_highestCard = Hand.Cards.First();
		}

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((HighCard) other) : 
				other.Probability.CompareTo(Probability);
		}

		public int CompareTo(HighCard other)
		{

			for (var i = 0; i < Hand.Cards.Count; i++)
			{
				var compareResult = Hand.Cards[i].CompareTo(other.Hand.Cards[i]);
				if (compareResult != 0)
				{
					return compareResult;
				}
			}

			return 0;
		}

		public override string ToString()
		{
			return string.Format("{0} High", _highestCard.Face);
		}
	}
}