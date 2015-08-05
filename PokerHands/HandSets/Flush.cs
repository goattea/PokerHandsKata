using System;
using System.Linq;

namespace PokerHands.HandSets
{
	public class Flush : IHandSet
	{

		public double Probability
		{
			get { return Constants.Probability.Flush; }
		}

		public Card HighCard { get; private set; }

		public Flush(Hand hand)
		{
			if (!DoesHandMeetCriteria(hand))
				throw new Exception(string.Format("Cannot compose Flush with hand {0}", hand));

			HighCard = hand.Cards.First();
		}


		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((Flush)other) : 
				other.Probability.CompareTo(Probability);
		}

		public int CompareTo(Flush other)
		{
			return HighCard.CompareTo(other.HighCard);
		}

		public override string ToString()
		{
			return string.Format("Flush {0} High", HighCard.Face);
		}

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			return hand.Cards.GroupBy(f => f.SuitChar).Count() == 1;
		}
	}
}