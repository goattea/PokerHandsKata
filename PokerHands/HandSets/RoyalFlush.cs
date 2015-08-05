using System;

namespace PokerHands.HandSets
{
	public class RoyalFlush : IHandSet
	{
		
		public double Probability
		{
			get { return Constants.Probability.RoyalFlush; }
		}
		public RoyalFlush(Hand hand)
		{
			if (!DoesHandMeetCriteria(hand))
				throw new Exception(string.Format("Cannot compose Royal Flush with hand {0}", hand));
		}

		public int CompareTo(IHandSet other)
		{
			return other.Probability.CompareTo(Probability); ;
		}

		public override string ToString()
		{
			return "Royal Flush";
		}

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			return Straight.IsAceHighStraight(hand) && Flush.DoesHandMeetCriteria(hand);
		}
	}
}