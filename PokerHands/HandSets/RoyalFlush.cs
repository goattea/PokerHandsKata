using System;

namespace PokerHands.HandSets
{
	public class RoyalFlush : IHandSet
	{
		
		public double Probability
		{
			get { return Constants.Probability.RoyalFlush; }
		}

		public string Name
		{
			get { return ToString(); }
		}

		public Hand Hand { get; private set; }

		public int CompareTo(IHandSet other)
		{
			return other.GetType() == GetType() ? 
				CompareTo((RoyalFlush)other) : 
				other.Probability.CompareTo(Probability); ;
		}

		public override string ToString()
		{
			return "Royal Flush";
		}

		public RoyalFlush(Hand hand)
		{
			Hand = hand;
			if(!DoesHandMeetCriteria(Hand))
				throw new Exception(string.Format("Cannot compose Royal Flush with hand {0}", Hand)); 
		}

		public static bool DoesHandMeetCriteria(Hand hand)
		{
			return Straight.IsAceHighStraight(hand) && Flush.DoesHandMeetCriteria(hand);
		}
	}
}